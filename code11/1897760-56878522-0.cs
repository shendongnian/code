    public static int FindSubArray<T>(this IReadOnlyList<T> sourceCollection, IReadOnlyList<T> collectionToFind)
        {
            for (var i = 0; i <= sourceCollection.Count - collectionToFind.Count; i++)
            {
                var matched = true;
                for (var j = 0; j < collectionToFind.Count; j++)
                {
                    if (sourceCollection[i + j].Equals(collectionToFind[j]))
                        continue;
                    matched = false;
                    break;
                }
                if (matched)
                    return i;
            }
            return -1;
        }
