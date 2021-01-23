        public static void ReadALotOfValues(StringBuilder b, object o, int lvl, int maxLvl)
        {
            Type t = o.GetType();
            List<PropertyInfo> l = new List<PropertyInfo>();
            while (t != typeof(object))
            {
                l.AddRange(t.GetProperties());
                t = t.BaseType;
            }
            foreach (var item in l)
            {
                if (item.CanRead && item.GetIndexParameters().Length == 0)
                {
                    object child = item.GetValue(o, null);
                    b.AppendFormat("{0}{1} = {2}\n", new string(' ', 4 * lvl), item.Name, child);
                    if (lvl < maxLvl)
                        ReadALotOfValues(b, child, lvl + 1, maxLvl);
                }
            }
        }
