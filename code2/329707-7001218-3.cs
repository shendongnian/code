        /// <summary>
        /// Inserts object and creates GeoIndex on collection (assumes TDocument is a class
        /// containing an array double[] Location where [0] is the x value (as longitude)
        /// and [1] is the y value (as latitude) - this order is important for spherical queries.
        /// 
        /// Collection name is assigned as typeof(TDocument).ToString()
        /// </summary>
        /// <param name="dbName">Your target database</param>
        /// <param name="data">The object you're storing</param>
        /// <param name="geoIndexName">The name of the location based array on which to create the geoIndex</param>
        /// <param name="indexNames">optional: a dictionary containing any additional fields on which you would like to create an index
        /// where the key is the name of the field on which you would like to create your index and the value should be either SortDirection.Ascending
        /// or SortDirection.Descending. NOTE: this should not include geo indexes! </param>
        /// <returns>void</returns>
        public static void MongoGeoInsert<TDocument>(string dbName, TDocument data, string geoIndexName, Dictionary<string, SortDirection> indexNames = null)
        {
            Connection connection = new Connection(dbName);
            MongoCollection collection = connection.GetMongoCollection<TDocument>(typeof(TDocument).Name, connection.Db);
            collection.Insert<TDocument>(data);
            /* NOTE: Latitude and Longitude MUST be wrapped in separate class or array */
            IndexKeysBuilder keys = IndexKeys.GeoSpatial(geoIndexName);
            IndexOptionsBuilder options = new IndexOptionsBuilder();
            options.SetName("idx_" + typeof(TDocument).Name);
            // since the default GeoSpatial range is -180 to 180, we don't need to set anything here, but if
            // we wanted to use something other than latitude/longitude, we could do so like this:
            // options.SetGeoSpatialRange(-180.0, 180.0);
            if (indexNames != null)
            {
                foreach (var indexName in indexNames)
                {
                    if (indexName.Value == SortDirection.Decending)
                    {
                        keys = keys.Descending(indexName.Key);
                    }
                    else if (indexName.Value == SortDirection.Ascending)
                    {
                        keys = keys.Ascending(indexName.Key);
                    }
                }
            }
            collection.EnsureIndex(keys, options);
            connection.Db.Server.Disconnect();
        }
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MongoDB.Bson;
    using MongoDB.Driver;
    
    namespace MyMongo.Helpers
    {
        public class Connection
        {
            private const string DbName = "";
            private const string Prefix = "mongodb://";
            //private const string Server = "(...):27017/";
            private const string Server = "localhost:27017/";
            private const string PassWord = "";
            private const string UserName = "";
            private const string Delimeter = "";
            //if using MongoHQ
            //private const string Delimeter = ":";
            //private const string Prefix = "mongodb://";
            //private const string DbName = "(...)";
            //private const string UserName = "(...)";
            //private const string Server = "@flame.mongohq.com:(<port #>)/";
            //private const string PassWord = "(...)";
            private readonly string _connectionString = string.Empty;
    
            public MongoDatabase Db { get; private set; }
            public MongoCollection Collection { get; private set; }
    
            public Connection()
            {
                _connectionString = Prefix + UserName + Delimeter + PassWord + Server + DbName;
            }
    
            public Connection(string dbName)
            {
                _connectionString = Prefix + UserName + Delimeter + PassWord + Server + DbName;
                Db = GetDatabase(dbName);
            }
    
            //mongodb://[username:password@]hostname[:port][/[database][?options]]
            public MongoDatabase GetDatabase(string dbName)
            {
                MongoServer server = MongoServer.Create(_connectionString);
                MongoDatabase database = server.GetDatabase(dbName);
                return database;
            }
    
            public MongoCollection<TDocument> GetMongoCollection<TDocument>(string collectionName, MongoDatabase db, SafeMode safeMode = null)
            {
                if (safeMode == null) { safeMode = new SafeMode(true); }
                MongoCollection<TDocument> result = db.GetCollection<TDocument>(collectionName, safeMode);
                return result;
            }
        }
    }
