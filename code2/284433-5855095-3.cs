    IEnumerable<Foo> selectedFoos =
        sampleDataSet
            .Distinct(new PerformantFooComparer())
            .Where(f => f.HasBar);
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
                    x.Baz == y.Baz
                    // && x.HasBar == y.HasBar
                    // HasBar commented out to avoid performance overhead.
                    // It is handled by a Where(foo => foo.HasBar) filter
                    );
        }
        public int GetHashCode(Foo obj)
        {
            if (obj == null)
                return 0;
            // See: http://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
            int hash = 17;
            hash = hash * 23 + obj.Baz.GetHashCode();
            // HasBar intentionally not hashed
            return hash;
        }
    }
