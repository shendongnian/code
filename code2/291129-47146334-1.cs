        public static Schema GetSchema(Type type)
        {
            if (_schemaLookup.TryGetValue(type, out Schema schema))
                return schema;
            lock (_syncRoot) {
                if (_schemaLookup.TryGetValue(type, out schema))
                    return schema;
                var newLookup = new Dictionary<Type, Schema>(_schemaLookup);
                foreach (var t in type.Assembly.GetTypes()) {
                    var newSchema = new Schema(t);
                    newLookup.Add(t, newSchema);
                }
                _schemaLookup = newLookup;
                return _schemaLookup[type];
            }
        }
