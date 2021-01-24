    public async Task<ActionResult> TransferOwnership(int sourceUserId, int targetUserId)
    {
        var metadata = ((IObjectContextAdapter)Context).ObjectContext.MetadataWorkspace;
        var tables = metadata.GetItems(DataSpace.SSpace).Where(x => x.BuiltInTypeKind == BuiltInTypeKind.EntityType).ToList();
        //some entities were cast to their proxy types which were unconvertable with Convert.ChangeType...
        Context.Configuration.ProxyCreationEnabled = false;
        foreach (var table in tables)
        {
            var tableName = table.GetType().GetProperty("Name").GetValue(table);
            var type = Assembly.GetAssembly(typeof(BaseEntity)).GetTypes().SingleOrDefault(x => x.Name == tableName.ToString());
            List<object> entities = await Context.Database.SqlQuery(type, $"SELECT * FROM {tableName} WHERE OwnerId = {sourceUserId}").ToListAsync();
            foreach (var entity in entities)
            {
                var e = entity as BaseEntity;
                e.OwnerId = targetUserId;
                Context.Set(type).Attach(Convert.ChangeType(e, type));
                Context.Entry(e).State = EntityState.Modified;
            }
            if (entities.Count > 0)
                Context.SaveDirect();
        }
        return Ok();
    }
