    class MyClass<W> : IDrilldown {
        void IDrilldown.AddCriteria<T>(T Criterion) {
            if (Criterion is W) {
                W value = (W)Convert.ChangeType(Criterion, typeof(W));
                // value is W, have fun
                // or - as Snowbear pointed out in the comments
                W value = (W)(object)Criterion;
                // works just as well....
            } else {
                // value is NOT W and could not be converted.
            }
        }
    }
