    IEnumerable<Foo> selectedFoos = sampleDataSet.Distinct(new PerformantFooComparer());
    // ...
    private class PerformantFooComparer : IEqualityComparer<Foo>
    {
        public bool Equals(Foo x, Foo y)
        {
            bool isXNull = x == null;
            bool isYNull = y == null;
            return isXNull == isYNull
                && isXNull
                || (
                    x.Baz == y.Baz // Short circuits if they are not equal
                    && x.HasBar == y.HasBar
                    );
        }
        public int GetHashCode(Foo obj)
        {
            if (obj == null)
                return 0;
            // See: http://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
            int hash = 17;
            hash = hash * 23 + obj.Baz.GetHashCode();
            return hash;
        }
    }
