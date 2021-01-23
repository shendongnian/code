        public static void UpdateManyToMany<TSingle, TMany>(
            this DbContext ctx,
            TSingle localItem,
            Func<TSingle, ICollection<TMany>> collectionSelector)
            where TSingle : class
            where TMany : class
        {
            DbSet<TSingle> localItemDbSet = ctx.Set(typeof(TSingle)).Cast<TSingle>();
            DbSet<TMany> manyItemDbSet = ctx.Set(typeof(TMany)).Cast<TMany>();
            ObjectContext objectContext = ((IObjectContextAdapter) ctx).ObjectContext;
            ObjectSet<TSingle> tempSet = objectContext.CreateObjectSet<TSingle>();
            IEnumerable<string> localItemKeyNames = tempSet.EntitySet.ElementType.KeyMembers.Select(k => k.Name);
            var localItemKeysArray = localItemKeyNames.Select(kn => typeof(TSingle).GetProperty(kn).GetValue(localItem, null));
            localItemDbSet.Load();
            TSingle dbVerOfLocalItem = localItemDbSet.Find(localItemKeysArray.ToArray());
            IEnumerable<TMany> localCol = collectionSelector(localItem)?? Enumerable.Empty<TMany>();
            ICollection<TMany> dbColl = collectionSelector(dbVerOfLocalItem);
            dbColl.Clear();
            ObjectSet<TMany> tempSet1 = objectContext.CreateObjectSet<TMany>();
            IEnumerable<string> collectionKeyNames = tempSet1.EntitySet.ElementType.KeyMembers.Select(k => k.Name);
            var selectedDbCats = localCol
                .Select(c => collectionKeyNames.Select(kn => typeof (TMany).GetProperty(kn).GetValue(c, null)).ToArray())
                .Select(manyItemDbSet.Find);
            foreach (TMany xx in selectedDbCats)
            {
                dbColl.Add(xx);
            }
            ctx.Entry(dbVerOfLocalItem).CurrentValues.SetValues(localItem);
        }
