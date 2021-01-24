var speedRows = context.TestData
.Where(a => a.Time >= start
&& a.Time < end
&& a.LocationTypeId == 3
&& a.channelId 7)
.Select(s => new
{
    s.Time,
    ChannelValue = (double)s.ChannelValue
})
.Distinct().ToList();
**Step 2** (rows with a channelId = torque):
var torqueRows = context.TestData
.Where(a => a.LocationTypeId == 3
&& a.channelId == 8)
.Select(s => new
{
    s.Time,
    ChannelValue = (short)s.ChannelValue
})
.Distinct().ToList();
**Step 3** (join the speed and torque rows from **Step 1** and **Step 2** on Time):
var joinedRows = speedRows.Join(torqueRows, arg => arg.Time, arg => arg.Time,
	(speed, torque) => new
	{
		Id = speed.Time,
		Speed = speed.ChannelValue,
		Torque = torque.ChannelValue
	});
**Step 4** (group the rows into keyed groups)
var groupedData = joinedRows
	.GroupBy(arg => new { TorqueGroupKey = (arg.Torque / 100), SpeedGroupKey = Math.Floor((arg.Speed) / 500) })
	.Select(g => new
	{
		g.Key.TorqueGroupKey,
		g.Key.SpeedGroupKey,
		Minutes = g.Count()
	});
**Step 5** (create the dynamic groupings using groupedData from **Step 4**):
var response = (from a in groupedData.AsEnumerable()
			group a by a.TorqueGroupKey into torqueGroup
			orderby torqueGroup.Key
			select new ResidencySqlResult
			{
				TorqueBracket = $"{100 * torqueGroup.Key} <> {100 + (100 * torqueGroup.Key)}",
				TorqueMin = 100 * torqueGroup.Key,
				TorqueMax = 100 + (100 * torqueGroup.Key),
				Speeds = (from d in torqueGroup
						  orderby d.SpeedGroupKey
						  select new Speeds
						  {
							  SpeedBracket = $"{500 * d.SpeedGroupKey} <> {500 + (500 * d.SpeedGroupKey)}",
							  SpeedMin = 500 * (int)d.SpeedGroupKey,
							  SpeedMax = 500 + (500 * (int)d.SpeedGroupKey),
							  Minutes = d.Minutes
						  })
			}).ToList();
Thank you again to all those that helped out.
