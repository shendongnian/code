        var queryIndexed = segments
            .Select(x => x.Followers.Select(y => new
                {
                    QIndex = Array.IndexOf(queryArray, y.Value),
                    y.Index,
                    y.Value
                }).ToArray());
        var queryOrdered = queryIndexed
            .Where(item =>
                {
                    var qindex = item.Select(x => x.QIndex).ToList();
                    bool changed;
                    do
                    {
                        changed = false;
                        for (int i = 1; i < qindex.Count; i++)
                        {
                            if (qindex[i] <= qindex[i - 1])
                            {
                                qindex.RemoveAt(i);
                                changed = true;
                            }
                        }
                    } while (changed);
                    return qindex.Count == queryArray.Length;
                });
