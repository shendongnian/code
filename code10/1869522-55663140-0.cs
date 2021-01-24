        public void MapValues(object dst, List<Parameter> source)
        {
            var dict = source.ToDictionary(x => x.Name, x => x);
            var fields = dst.GetType().GetProperties().ToList();
            fields.ForEach(x =>
            {
                var param = dict.ContainsKey(x.Name) ? dict[x.Name] : null;
                if(param != null)
                    x.SetValue(dst, param.Value);
            });
        }
        public Class_A(List<Parameter> parameters)
        {
            MapValues(this, parameters);
        }
If you intent to use the same pattern in other classes it would be better to move MapValues into a different utility class
