    static T[] GetGroupSums<T>(IEnumerable<T> collection, Expression<Func<T, object>> memberExpression) where T : new()
    {
        //get the PropertyInfo you want to sum
        var sumProp = (PropertyInfo)((MemberExpression)((UnaryExpression)memberExpression.Body).Operand).Member;
        //get all PropertyInfos that are not the property to sum
        var groupProps = typeof(T).GetProperties().Where(x => x != sumProp).ToArray();
        //group them by a hash of non-summed properties
        var groups = collection
            .GroupBy(x => GeneralUtilities.GetHash(groupProps.Select(pi => pi.GetValue(x)).ToArray()))
            .Select(items =>
            {
                var item = new T();
                //clone the first item
                foreach (var gp in groupProps)
                {
                    gp.SetValue(item, gp.GetValue(items.First()));
                }
                //Get a decimal sum and then convert back to the sum property type. If it will
                var sum = items.Sum(_item => (decimal)Convert.ChangeType(sumProp.GetValue(_item), typeof(decimal)));
                sumProp.SetValue(item, Convert.ChangeType(sum, sumProp.PropertyType));
                //If it will always be int, just do this
                //var sum = items.Sum(_item => (int)sumProp.GetValue(_item));
                //sumProp.SetValue(item, sum);
                return item;
            });
        return groups.ToArray();
    }
    //I got this hash method off StackExchange many years back
    public static int GetHash(params object[] args)
    {
        unchecked
        {
            int hash = 17;
            foreach (object arg in args)
            {
                hash = hash * 23 + arg.GetHashCode();
            }
            return hash;
        }
    }
