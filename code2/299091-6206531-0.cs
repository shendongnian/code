    public static IList<TEntity> GetObjectListFromArray(int[] IDs)
    {
        var r = new List<TEntity>();
        foreach (var item in IDs)
        {
            var obj = typeof(TEntity).Assembly.CreateInstance(typeof(TEntity).FullName);
            var p = obj.GetType().GetProperty("Id", System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            if (p != null)
            {
                p.SetValue(obj, item, null);
                var m = r.GetType().GetMethod("Add");
                m.Invoke(r, new object[] { obj });
            }
        }
        return r;
    }
