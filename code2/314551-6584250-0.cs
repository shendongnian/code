            var query = Query.And(Query.EQ("_id", applicationId),
                             Query.EQ("Settings.Key",  "ImportDirectory"));
            var update = Update.Pull("Settings.$.Overrides", new BsonDocument(){
                { "Name", "PathDirectory" }
            });
            database.Applications().Update(query, update);
