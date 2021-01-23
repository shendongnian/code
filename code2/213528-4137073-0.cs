    var temp = (from blobID in blobIds
                join blob in blobs on blobID.Value.HashKey equals blob.HashKey
                select new {
                    blobID.Key,
                    Binder = Load(blob)
                }
               ).Distinct()
                .ToDictionary(arg => arg.Key, arg => arg.Binder);
