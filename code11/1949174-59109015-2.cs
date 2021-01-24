        public Entity GetByName(string name)
        {
            int id;
            var dic = _cache as IDictionary<int, string>;
            if (!dic.Values.Contains(name))
            {
                var _entity = db.GetByName(name);
                _cache.Set(_entity.Id, _entity.Name);
                id = _entity.Id;
            }
            else
            {
                id = dic.FirstOrDefault(x => x.Value == name).Key;
            }
            return _cache.Get<Entity>(id);
        }
