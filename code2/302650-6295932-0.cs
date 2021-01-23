            public static DataTable ToDataTable<T>( this List<T> list) where T : class {
            Type type = typeof(T);
            var ps = type.GetProperties ( );
            var cols = from p in ps
                       select new DataColumn ( p.Name , p.PropertyType );
            DataTable dt = new DataTable();
            dt.Columns.AddRange(cols.ToArray());
            list.ForEach ( (l) => {
                List<object> objs = new List<object>();
                objs.AddRange ( ps.Select ( p => p.GetValue ( l , null ) ) );
                dt.Rows.Add ( objs.ToArray ( ) );
            } );
            return dt;
        }
