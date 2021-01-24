    public static class Extensions
    {
        private static new Dictionary<string, Func<test, int[]>> accessor =
            new Dictionary<string, Func<test, int[]>>
            {
                { nameof(test.valuesOne), x => x.valuesOne },
                { nameof(test.valuesTwo), x => x.valuesTwo }
            };
    
        public static int[] Property(this test t, string name)
        {
            return accessor[name](t);
        }
    }
