    return content.Aggregate(new List<List<T>>(), (lists, value) => {
                                 if (lists.Count == 0 || isSectionDivider(value)) {
                                     lists.Add(new List<T>());
                                 };
                                 lists[lists.Count - 1].Add(value);
                                 return lists;
                             });
