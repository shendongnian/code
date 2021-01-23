        public static List<Tuple<object, string, int>> EnumToList(Type t)
        {
            return Enum
                .GetValues(t)
                .Cast<object>()
                .Select(x=>Tuple.Create(x, x.ToString(), (int)x))
                .ToList();
        }
