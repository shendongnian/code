       public static decimal MedianBy<T, TResult>(this IQueryable<T> sequence, Expression<Func<T, TResult>> getValue)
    {
        var count = sequence.Count();
        //Use Expression bodied fuction otherwise it won't be translated to SQL query
        var list = sequence.OrderByDescending(getValue).Select(getValue);
        var mid = count / 2;
        if (mid == 0)
        {
            throw new InvalidOperationException("Empty collection");
        }
        if (count % 2 == 0)
        {
            var elem1 = list.Skip(mid - 1).FirstOrDefault();
            var elem2 = list.Skip(mid).FirstOrDefault();
            return (Convert.ToDecimal(elem1) + Convert.ToDecimal(elem2)) / 2M;
            //TODO: search for a way to devide 2 for different types (int, double, decimal, float etc) till then convert to decimal to include all posibilites
        }
        else
        {
            return Convert.ToDecimal(list.Skip(mid).FirstOrDefault());
            //ElementAt Doesn't work with SQL
            //return list.ElementAt(mid);
        }
    }
