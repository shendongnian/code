    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.GridFS;
    using System.IO;
    using System.Threading.Tasks;
    
    namespace MongoGridFSTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var client = new MongoClient("mongodb://localhost");
                var database = client.GetDatabase("TestDB");
                var fs = new GridFSBucket(database);
                
                var id = UploadFile(fs);
    
                DownloadFile(fs, id);
            }
    
            private static ObjectId UploadFile(GridFSBucket fs)
            {
                using (var s = File.OpenRead(@"c:\temp\test.txt"))
                {
                    var t = Task.Run<ObjectId>(() => { return 
                        fs.UploadFromStreamAsync("test.txt", s);
                    });
    
                    return t.Result;
                }
            }
    
            private static void DownloadFile(GridFSBucket fs, ObjectId id)
            {
                //This works
                var t = fs.DownloadAsBytesByNameAsync("test.txt");
                Task.WaitAll(t);
                var bytes = t.Result;
    
    
                //This blows chunks (I think it's a driver bug, I'm using 2.1 RC-0)
                var x = fs.DownloadAsBytesAsync(id);
                Task.WaitAll(x);
            }
        }
    }
