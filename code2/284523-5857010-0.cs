    public static List<TItem> Cast<TItem>(this DataRowCollection drc, Func<DataRow, TItem> converter)
        {
            List<TItem> list= new List<TItem>();
            foreach (DataRow row in drc)
            {
                list.Add(converter(row));
            }
            return list;
        }
