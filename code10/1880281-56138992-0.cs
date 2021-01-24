    static class ExtensionMethods
    {
        public static T GetObject<T>(
            this ObjectId id, 
            OpenMode mode = OpenMode.ForRead,
            bool openErased = false, 
            bool forceOpenOnLockedLayer = false)
            where T : DBObject
        {
            return (T)id.GetObject(mode, openErased, forceOpenOnLockedLayer);
        }
        public static BlockTableRecord GetModelSpace(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return SymbolUtilityServices.GetBlockModelSpaceId(db).GetObject<BlockTableRecord>(mode);
        }
        public static ObjectId Add (this BlockTableRecord owner, Entity entity)
        {
            var tr = owner.Database.TransactionManager.TopTransaction;
            var id = owner.AppendEntity(entity);
            tr.AddNewlyCreatedDBObject(entity, true);
            return id;
        }
    }
