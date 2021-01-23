        public T GetResult<T>(int id, string typeName) where T : IClassWithTypeID {
            YourEntities db = new YourEntities();
            var result = db.CreateQuery<T>(String.Format("[{0}]", typeName));
            return result.Single(t => t.TypeID == id);
        }
