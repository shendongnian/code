            public IEnumerable<IEnumerable<T>> ToLists<T>(IEnumerable<T> sequence)
            {
                var res = sequence.Select((item, position) => new { Item = item, Position = position })
                                  .GroupBy(pair => pair.Position % 2 == 0,pair => pair.Item);
                return from grouping in res
                       select grouping;
            }
