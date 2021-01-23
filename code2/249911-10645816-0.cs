    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    using MongoDB.Bson;
    using MongoDB.Driver.Builders;
    using MongoDB.Driver.GridFS;
    using System.IO;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            MongoServer ms = MongoServer.Create();
            string _dbName = "docs";
            MongoDatabase md = ms.GetDatabase(_dbName);
            if (!md.CollectionExists(_dbName))
            {
                md.CreateCollection(_dbName);
            }
            MongoCollection<Doc> _documents = md.GetCollection<Doc>(_dbName);
            _documents.RemoveAll();
            //add file to GridFS
            MongoGridFS gfs = new MongoGridFS(md);
            MongoGridFSFileInfo gfsi = gfs.Upload(@"c:\mongodb.rtf");
            _documents.Insert(new Doc()
            {
                DocId = gfsi.Id.AsObjectId,
                DocName = @"c:\foo.rtf"
            }
            );
            foreach (Doc item in _documents.FindAll())
            {
                ObjectId _documentid = new ObjectId(item.DocId.ToString());
                MongoGridFSFileInfo _fileInfo = md.GridFS.FindOne(Query.EQ("_id", _documentid));
                gfs.Download(item.DocName, _fileInfo);
                Console.WriteLine("Downloaded {0}", item.DocName);
                Console.WriteLine("DocName {0} dowloaded", item.DocName);
            }
            Console.ReadKey();
        }
    }
    class Doc
    {
        public ObjectId Id { get; set; }
        public string DocName { get; set; }
        public ObjectId DocId { get; set; }
    }
}
