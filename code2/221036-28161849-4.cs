        enum PermutationsOption {
            None,
            SkipEmpty,
            SkipNotDistinct
        }
        private IEnumerable<IEnumerable<T>> Permutations<T>(IEnumerable<T> elements, PermutationsOption option = PermutationsOption.None, IEqualityComparer<T> equalityComparer = default(IEqualityComparer<T>)) {
            var elementsList = new List<IEnumerable<T>>();
            var elementsIndex = 0;
            var elementsCount = elements.Count();
            var elementsLength = Math.Pow(elementsCount + 1, elementsCount);
            if (option.HasFlag(PermutationsOption.SkipEmpty)) {
                elementsIndex = 1;
            }
            if (elements.Count() > 0) {
                do {
                    var elementStack = new Stack<T>();
                    for (var i = 0; i < elementsCount; ++i) {
                        var ind = (int)(elementsIndex / Math.Pow(elementsCount + 1, i) % (elementsCount + 1));
                        if (ind == 0) {
                            continue;
                        }
                        elementStack.Push(elements.ElementAt(ind - 1));
                    }
                    var elementsCopy = elementStack.ToArray() as IEnumerable<T>;
                    if (option.HasFlag(PermutationsOption.SkipNotDistinct)) {
                        elementsCopy = elementsCopy.Distinct();
                        elementsCopy = elementsCopy.ToArray();
                        if (elementsList.Any(p => CompareItemEquality(p, elementsCopy, equalityComparer))) {
                            continue;
                        }
                    }
                    elementsList.Add(elementsCopy);
                } while (++elementsIndex < elementsLength);
            }
            return elementsList.ToArray();
        }
        private bool CompareItemEquality<T>(IEnumerable<T> elements1, IEnumerable<T> elements2, IEqualityComparer<T> equalityComparer = default(IEqualityComparer<T>)) {
            if (equalityComparer == null) {
                equalityComparer = EqualityComparer<T>.Default;
            }
            return (elements2.Count() == elements2.Count()) && (elements2.All(p => elements1.Contains(p, equalityComparer)));
        }
