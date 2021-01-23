    public static IQueryable<T> SkipTakeQuery<T>(this IQueryable<T> query, int skipIndex, int takeIndex)
            {
                if (skipIndex == -1)
                {
                    return query;
                }
                return query.Skip(skipIndex).Take(takeIndex);
            }
