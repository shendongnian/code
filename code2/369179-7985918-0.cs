            var localDetails = new List<SyncFile> 
            {
                new SyncFile { ModifyDate = DateTime.Now, RelativeFilePath = "c:\\help", Id = 1 },
                new SyncFile { ModifyDate = DateTime.Now.AddDays(1), RelativeFilePath = "c:\\wow", Id = 2 },
                new SyncFile { ModifyDate = DateTime.Now, RelativeFilePath = "c:\\y", Id = 6 },
            };
            var remoteDetails = new List<SyncFile>()
            {
                new SyncFile { ModifyDate = DateTime.Now.AddDays(-1), RelativeFilePath = "c:\\help", Id = 3 },
                new SyncFile { ModifyDate = DateTime.Now.AddDays(5), RelativeFilePath = "c:\\wow", Id = 4 },
                new SyncFile { ModifyDate = DateTime.Now, RelativeFilePath = "c:\\x", Id = 5 },
            };
            var results = localDetails.Join(remoteDetails, l => l.RelativeFilePath, r => r.RelativeFilePath, (lf, rf) => lf.ModifyDate > rf.ModifyDate ? lf : rf);
            foreach(var result in results)
            {
                Console.WriteLine(result.Id);
            }
