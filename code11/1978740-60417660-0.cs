    public static (IEnumerable<T>first,IEnumerable<T> second) Span<T>(this ReadOnlyMemory<T> original,Func<T,bool> predicate) {
                List<T> list = new List<T>();
                
                int splitIndex = 0;
                for (int i = 0; i < original.Length && !predicate(original.Span[i]); i++) {
                    list.Add(original.Span[splitIndex=i]);
                }
                var part2 = original.Slice(splitIndex);
                return (list, part2.ToArray());
            }
