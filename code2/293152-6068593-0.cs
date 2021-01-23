            var query = from sf in sfcoll.AsParallel().WithDegreeOfParallelism(sfcoll.Count())
                        let p = ProcessShellObject(sf, curExeName)
                        select p;
            foreach(var q in query) 
            {
                // ....
            }
            // or:
            var results = query.ToArray(); // also enumerates query
