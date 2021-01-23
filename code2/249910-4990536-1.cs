     var server = MongoServer.Create("mongodb://localhost:27020");
     var database = server.GetDatabase("tesdb");
    
     var fileName = "D:\\Untitled.png";
     var newFileName = "D:\\new_Untitled.png";
     using (var fs = new FileStream(fileName, FileMode.Open))
     {
        var gridFsInfo = database.GridFS.Upload(fs, fileName);
        var fileId = gridFsInfo.Id;
        ObjectId oid= new ObjectId(fileId);
        var file = database.GridFS.FindOne(Query.EQ("_id", oid));
        using (var stream = file.OpenRead())
        {
           var bytes = new byte[stream.Length];
           stream.Read(bytes, 0, (int)stream.Length);
           using(var newFs = new FileStream(newFileName, FileMode.Create))
           {
             newFs.Write(bytes, 0, bytes.Length);
           } 
        }
     }
