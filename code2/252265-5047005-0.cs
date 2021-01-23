        public T GetResult<T>(int id, string typeName) where T : IClassWithTypeID {
            AccrualTrackingEntities db = new AccrualTrackingEntities();
            var result = db.CreateQuery<T>(String.Format("[{0}]", typeName));
            return result.Single(t => t.TypeID == id);
        }
