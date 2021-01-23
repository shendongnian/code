    public static class ExtendedClassPropMapping
    {
        public static Y MapTo<Y>(this object input) where Y : class, new()
        {
            Y output = new Y();
            var propsT = input.GetType().GetProperties();
            var propsY = typeof(Y).GetProperties();
            var similarsT = propsT.Where(x =>
                          propsY.Any(y => y.Name == x.Name
                   && y.PropertyType == x.PropertyType)).OrderBy(x => x.Name).ToList();
            var similarsY = propsY.Where(x =>
                            propsT.Any(y => y.Name == x.Name
                    && y.PropertyType == x.PropertyType)).OrderBy(x => x.Name).ToList();
            for (int i = 0; i < similarsY.Count; i++)
            {
                similarsY[i]
                .SetValue(output, similarsT[i].GetValue(input, null), null);
            }
            return output;
        }
        public static T MapNew<T>(this T input) where T : class, new()
        {
            T output = new T();
            var similarsT = input.GetType().GetProperties().OrderBy(x => x.Name).ToList();
            var similarsY = output.GetType().GetProperties().OrderBy(x => x.Name).ToList();
            for (int i = 0; i < similarsY.Count; i++)
            {
                similarsY[i]
                .SetValue(output, similarsT[i].GetValue(input, null), null);
            }
            return output;
        }
    }
