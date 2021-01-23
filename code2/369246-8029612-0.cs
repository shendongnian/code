     internal static void GetPartitionsClosestTo9999(List<long> primeFactors, out long partition1, out long partition2)
            {
                for (var index = 9999; index >= 2; index--)
                {
                    var primeFactorsForCurrentIndex = GetPrimeFactors(index);
                    var isSubset = IsSubSet(primeFactorsForCurrentIndex, primeFactors); //!primeFactorsForCurrentIndex.Except(primeFactors).Any();
                    if (isSubset)
                    {
                        partition1 = index;
                        foreach (var primeFactorForCurrentIndex in primeFactorsForCurrentIndex)
                        {
                            primeFactors.Remove(primeFactorForCurrentIndex);
                        }
                        partition2 = GetProduct(primeFactors);
                        return;
                    }
                }
                throw new ApplicationException("No subset found.");
            }
    
            static bool IsSubSet<T>(ICollection<T> set, IEnumerable<T> toCheck)
            {
                return set.Count == (toCheck.Intersect(set)).Count();
            }
