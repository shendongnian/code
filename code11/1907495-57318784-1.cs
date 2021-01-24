        public override int SaveChanges()
        {
            var trackedStates = new[] { EntityState.Added, EntityState.Modified };
            var trackedParentIds = ChangeTracker.Entries<Parent>().Where(x => trackedStates.Contains(x.State)).Select(x => x.Entity.ParentId).ToList();
            var addedSons = ChangeTracker.Entries<ASon>().Where(x => x.State == EntityState.Added).ToList();
            var modifiedSons = ChangeTracker.Entries<ASon>().Where(x => x.State == EntityState.Modified).ToList();
            int tempid = -1;
            int modifiedParentCount = addedSons.Select(x => x.Entity.Parent.ParentId)
                .Where(x => trackedParentIds.Contains(x))
                .Count();
            List<Tuple<Parent, ASon>> associatedSons = new List<Tuple<Parent, ASon>>();
            modifiedSons.ForEach(x => { x.State = EntityState.Unchanged; });
            addedSons.ForEach(x =>
            {
                x.Entity.SonId = tempid--;
                associatedSons.Add(new Tuple<Parent, ASon>(x.Entity.Parent, x.Entity));
                x.Entity.Parent.Sons.Remove(x.Entity);
                x.State = EntityState.Unchanged;
            });
            var result = base.SaveChanges();
            addedSons.ForEach(x => { x.Entity.Parent = associatedSons.Single(a => a.Item2 == x.Entity).Item1; x.State = EntityState.Added; });
            modifiedSons.ForEach(x => { x.State = EntityState.Modified; });
            result += base.SaveChanges() - modifiedParentCount;
            return result;
        }
