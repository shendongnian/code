        private async Task<IDictionary<int, IEnumerable<MyRecord>> BuildCache()
        {
            var records = await _repo.GetAll();
            return BuildMap(records);
        }
        private IDictionary<int, IEnumerable<MyRecord>> BuildMap(IEnumerable<MyRecord> records)
        {
            var map = records?
                .GroupBy(x => x.PersonId)
                .ToDictionary((k) => k.Key, (v) => v.Select(t => { t.Title = string.Intern(t.Title); return t; }));
            return map;
        }
