internal async Task<ICollection<Link>> getItemLink(ItemLinkParameters parameters, string db, string collection)
        {
            //gets mongo connection string and database name from the
            //MongoDatabaseSettings class which gets it from appsettings.json
            var client = new MongoClient(_dbsettings.ConnectionString);
            var database = client.GetDatabase(db);
            //uses the name from MongoCollectionName variable, set by MongoDatabaseSettings.cs, again supplied from appsettings.json
            var _linkDocs = database.GetCollection<Link>(collection);
            var leftFilter = Builders<Link>.Filter.Eq(x => x.LeftId, parameters.Id);
            var rightFilter = Builders<Link>.Filter.Eq(x => x.RightId, parameters.Id);
            
            
            if (parameters.Database != null && parameters.Database.Count() > 0)
            {
                leftFilter &= Builders<Link>.Filter.In(x => x.RightDatabase, parameters.Database);
                rightFilter &= Builders<Link>.Filter.In(x => x.LeftDatabase, parameters.Database);
            }
            if (parameters.Collection != null && parameters.Collection.Count() > 0)
            {
                leftFilter &= Builders<Link>.Filter.In(x => x.RightCollection, parameters.Collection);
                rightFilter &= Builders<Link>.Filter.In(x => x.LeftCollection, parameters.Collection);
            }
            // get data with paging
            var filter = Builders<Link>.Filter.Or(leftFilter, rightFilter);
            if (parameters.RelationshipId != null && parameters.RelationshipId.Count > 0)
            {
                filter &= Builders<Link>.Filter.In(x => x.RelationshipId, parameters.RelationshipId);
            }
            var qry = _linkDocs.Find(filter)
                .Skip((parameters.Page - 1) * parameters.PageLimit)
                .Limit(parameters.PageLimit);
            var data = await qry.ToListAsync();
            return data;
        }
