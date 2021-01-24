        void TestFunction()
        {
            var v1 = new { yes = "asdf", no = "as", ar = new List<int>() { 1, 2, 3 }, dict = new Dictionary<object, object>() { { 1, 1 }, { 2, 2 } } };
            var v2 = new { yes = "asdf", no = "fd", ar = new List<int>() { 1, 2, 3 }, dict = new Dictionary<object, object>() { { 1, 1 }, { 2, 2 } } };
            var differences = DetailedCompare(v1, v2);
        }
        public static List<Variance> DetailedCompare<T>(T val1, T val2)
        {
            List<Variance> variances = new List<Variance>();
            PropertyInfo[] proppertyInfo = val1.GetType().GetProperties();
            foreach (PropertyInfo p in proppertyInfo)
            {
                Variance v = new Variance();
                v.Prop = p.Name;
                v.valA = p.GetValue(val1);
                v.valB = p.GetValue(val2);
                switch (v.valA)
                {
                    case null when v.valB == null:
                        continue;
                    case null:
                        variances.Add(v);
                        continue;
                }
                if (v.valA.Equals(v.valB)) continue;
                if (typeof(IEnumerable).IsAssignableFrom(p.PropertyType))
                {
                    //string
                    if (p.PropertyType == typeof(string))
                    {
                        variances.Add(v);
                        continue;
                    }
                    var args = p.PropertyType.GetGenericArguments();
                    MethodInfo exceptMethods = null;
                    if (args.Length == 2) //dictionaries
                    {
                        //variances.Add(v); // add to difference while not able to compare
                        var typeKeyValuePair = typeof(KeyValuePair<,>);
                        Type[] typeArgs = { args[0], args[1] };
                        exceptMethods = typeof(Enumerable)
                            .GetMethods(BindingFlags.Static | BindingFlags.Public)
                            .FirstOrDefault(mi => mi.Name == "Except")
                            ?.MakeGenericMethod(typeKeyValuePair.MakeGenericType(typeArgs));
                    }
                    else if (args.Length == 1)//lists
                    {
                        exceptMethods = typeof(Enumerable)
                            .GetMethods(BindingFlags.Static | BindingFlags.Public)
                            .FirstOrDefault(mi => mi.Name == "Except")
                            ?.MakeGenericMethod(p.PropertyType.GetGenericArguments().FirstOrDefault());
                    }
                    else//not 
                    {
                        variances.Add(v);
                    }
                    if (exceptMethods != null)
                    {
                        try
                        {
                            var res1 = (IEnumerable)exceptMethods.Invoke(v.valA, new[] { v.valA, v.valB });
                            var res2 = (IEnumerable)exceptMethods.Invoke(v.valB, new[] { v.valB, v.valA });
                            // TODO: maybe implement better comparisson 
                            if (res1.OfType<object>().Any() != res2.OfType<object>().Any()) variances.Add(v);
                        }
                        catch (Exception ex)
                        {
                        }
                        /* if (v.valA.Except(v.valB).Any() || v.valB.Except(v.valA).Any())
                        {
                            variances.Add(v);
                        }*/
                    }
                }
            }
            return variances;
        }
        public class Variance
        {
            public string Prop { get; set; }
            public object valA { get; set; }
            public object valB { get; set; }
            public override string ToString() => $" Property {Prop} is either {valA} resp. {valB}";
        }
