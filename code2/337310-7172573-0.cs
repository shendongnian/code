        private const float MIN_ACCEPT_VALUE = 0.0001f;
        public static void IsAcceptableDifference(IList collection, IList oldCollection)
        {
            if (collection == null)
                throw new Exception("Source collection is null");
            if (oldCollection == null)
                throw new Exception("Old collection is null");
            if (collection.Count != oldCollection.Count)
                throw new Exception("Different lenghts");
            for (int i = 0; i < collection.Count; i++)
            {
                float newValue = (float)collection[i];
                float oldValue = (float)oldCollection[i];
                float difference = Math.Abs(oldValue - newValue);
                if (difference < MIN_ACCEPT_VALUE)
                {
                    throw new Exception(
                        string.Format(
                            "Found a difference of {0} at index {1}",
                            difference,
                            i));
                }
            }
        }
