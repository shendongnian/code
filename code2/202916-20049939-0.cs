            public static IEnumerable<IEnumerable<T>> SplitMaintainingOrder<T>(this IEnumerable<T> list, int parts)
        {
            if (list.Count() == 0) return Enumerable.Empty<IEnumerable<T>>();
            var toreturn = new List<IEnumerable<T>>();
            var splitFactor = Decimal.Divide((decimal)list.Count(), parts);
            int currentIndex = 0;
            for (var i = 0; i < parts; i++)
            {
                var toTake = Convert.ToInt32(
                    i == 0 ? Math.Ceiling(splitFactor) : (
                        (Decimal.Compare(Decimal.Divide(Convert.ToDecimal(currentIndex), Convert.ToDecimal(i)), splitFactor) > 0) ? 
                            Math.Floor(splitFactor) : Math.Ceiling(splitFactor)));
                toreturn.Add(list.Skip(currentIndex).Take(toTake));
                currentIndex += toTake;
            }
            return toreturn;
        }
