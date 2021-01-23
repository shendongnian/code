    public static class Extensions
    {
        private static Func<HashSet<string>, string, string> getHashSetInternalValue;
  
        static Extensions()
        {
            ParameterExpression targetExp = Expression.Parameter(typeof(HashSet<string>), "target");
            ParameterExpression itemExp = Expression.Parameter(typeof(string), "item");
            var slotsExp = Expression.Field(targetExp, typeof(HashSet<string>).GetField("m_slots", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance));
            var indexExp = Expression.Call(targetExp, typeof(HashSet<string>).GetMethod("InternalIndexOf", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance), itemExp);
            var slotExp = Expression.ArrayAccess(slotsExp, indexExp);
            var valueExp = Expression.Field(slotExp, "value");
            var testExp = Expression.GreaterThanOrEqual(indexExp, Expression.Constant(0));
            var conditionExp = Expression.Condition(testExp, valueExp, Expression.Constant(null, typeof(string)));
            getHashSetInternalValue = Expression.Lambda<Func<HashSet<string>, string, string>>(conditionExp, new[] { targetExp, itemExp }).Compile();
        }
        /// <summary>
        /// Gets the internal item value equal to <paramref name="item"/> or null if <paramref name="item"/> is not contained
        /// </summary>
        public static string GetInternalValue(this HashSet<string> hashet, string item)
        {
            return getHashSetInternalValue(hashet, item);
        }
    }
