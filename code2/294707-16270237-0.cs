      public static string GetTableName<T>(this ObjectContext context) where T : EntityObject
        {
            var entities= context.MetadataWorkspace.GetItems(System.Data.Metadata.Edm.DataSpace.CSpace).Where(b => b.BuiltInTypeKind == BuiltInTypeKind.EntityType);
            foreach (System.Data.Metadata.Edm.EntityType item in entities)
            {
                if(item.FullName==typeof(T).FullName)
                    return item.Name;
            }
            return String.Empty;
        }
