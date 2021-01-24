csharp
var result = collection.AsQueryable()
               .Where(c => c.Id == "5e4606e6ae7b090688671416")
               .SelectMany(c => c.Episodes,
                           (c, e) => new
                           {
                               cid = c.Id,
                               cname = c.Name,
                               eid = e.Id,
                               ename = e.Name,
                               etracks = (Track[])e.Tracks.Where(t => t.Id == "5e460dbe2bc5e70c9cfeac21")
                           })
               .Where(x => x.etracks.Any())
               .Select(x => new Channel
               {
                   ID = x.cid,
                   Name = x.cname,
                   Episodes = new Episode[] {
                       new Episode {
                           Id = x.eid,
                           Name = x.ename,
                           Tracks = x.etracks } }
               })
               .ToList();
