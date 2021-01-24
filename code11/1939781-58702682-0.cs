var expiry = DateTime.UtcNow.AddMinutes(-30);
while(true)
{
    var devices = await _dbContext.Devices.Where(x => x.IsOnline && x.UpdateDateTime < expiry).ToListAsync;
    foreach (var device in devices)
    {
       device.IsOnline = false;
       device.UpdateDateTime = dateTime;
    }
    await _dbContext.SaveChangesAsync();
    Thread.Sleep(5000);
}
If you must use the `StatusDuration` then your current query should be efficient enough, however another option is to change the `ChangeOnline` method to set the expiry time, not a duration, now we are moving the most inefficient aspect of your query to the write process which will improve reading, seeing we will be reading far more frequently than writing , this is usally the best trade off to make.
public async Task ChangeOnline(int id, bool isOnline, int statusDuration )
{
    var device = await _dbContext.Devices.SingleOrDefaultAsync(x => x.Id == id);  
    if (device.IsOnline != isOnline)
    {
        device.IsOnline = isOnline;
        device.StatusDuration = statusDuration;
        device.UpdateDateTime = DateTime.UtcNow;
        device.ExpiryDateTime = DateTime.UtcNow.AddMinutes(statusDuration);
        await _dbContext.SaveChangesAsync();
    }
}
Then you only need to lookup the expiry column, no functions:
var now = DateTime.UtcNow;
while(true)
{
    var devices = await _dbContext.Devices
                                  .Where(x => x.IsOnline && x.ExpiryDateTime <= now)
                                  .Take(batchSize)
                                  .ToListAsync;
...
You should also make sure that there is an index on your `Devices` table on `IsOnline` and `UpdateDateTime` (or ExpiryDateTime if you go this way)
CREATE INDEX IX_DeviceExpiryCheck
ON Devices (IsOnline, UpdateDateTime);
This is a pretty efficient query with the index in the DB, so I wouldn't advocate bringing back more data and caching it locally, it's not really an option in many use cases because other processes are likely to call your `ChangeOnline` or otherwise modify `IsOnline` and `UpdateDateTime` so your cached result set would need to be refreshed periodically anyway.
If there are a large number of devices (more than 100) that are likely to be expired, then the update statement may take more resources and may interrupt your pipeline if too many changes are made at once. If this becomes a problem you could batch the lookup, the following is IMO the most efficient solution to your issue:
var now = DateTime.UtcNow;
int recordCount = 0;
int batchSize = 50;
while(true)
{
    do 
    {
        var devices = await _dbContext.Devices
                                      .Where(x => x.IsOnline && x.ExpiryDateTime <= now)
                                      .Take(batchSize)
                                      .ToListAsync;
        foreach (var device in devices)
        {
           device.IsOnline = false;
           device.UpdateDateTime = dateTime;
        }
        await _dbContext.SaveChangesAsync();
        Thread.Sleep(1000); // reduce the DTUs on the db by spreading the updates out a bit
    } while(recordCount == batchSize && recordCount > 0); // just in case you set batch size to zero ;)
    Thread.Sleep(5000);
}
The final thing to consider is change the frequency of the check out to 1 or 5 minutes, instead of 5 seconds. 
This is a business decision that can have a huge impact on performance, do you really need to know within 5 seconds if a device hasn't been active in the last X minutes? if it hasn't been active in 30 minutes, what is the difference between 00:30:00 and 00:30:05 or 00:31:00?
> I'm part of a team that manages a large number IoT devices we have a pattern similar to yours for monitoring what we call the heart beat. In the end we removed the concept of IsOnline from the database altogether and just use a field like the `UpdateDateTime` on its own, to reduce writes to the DB, the conceptual field of `IsOnline` is therefore mved to the business logic layer as a runtime comparison on the `UpdateDateTime`. Such a change is likely to substantial to your current business logic and queries but it's another option to consider.
