    static public EnumerableRowCollection<DataRow>
        OrderBy( this EnumerableRowCollection<DataRow> ys, DataTable dtbl, string sort )
    {
        OrderedEnumerableRowCollection<DataRow> oys = null;
        foreach ( string s in (sort ?? "").Split(new []{", "}, StringSplitOptions.None) )
        {
            int n = s.IndexOf(" desc");
	        string x = n!=-1 ? s.Substring(0, n) : s;
            Type typ = dtbl.Columns[x].DataType;
            Func<DataRow,dynamic> vfn = y=>yget[typ](y,x); // v1: vfn = y.Field<dynamic>(x)
            if ( oys==null )
                 oys = s.Contains(" desc") ? ys.OrderByDescending(vfn) : ys.OrderBy(vfn);
            else oys = s.Contains(" desc") ? oys.ThenByDescending(vfn) : oys.ThenBy(vfn);
        }
        return oys ?? ys;
    }
    static hMapT<Type,Func<DataRow,string,dynamic>>
        yget = new hMapT<Type,Func<DataRow,string,dynamic>>
    {
        {typeof(bool),     (y,x)=>y.Field<bool>(x)},
        {typeof(short),    (y,x)=>y.Field<short>(x)},
        {typeof(int),      (y,x)=>y.Field<int>(x)},
        {typeof(string),   (y,x)=>y.Field<string>(x)},
        {typeof(decimal),  (y,x)=>y.Field<decimal>(x)},
        {typeof(float),    (y,x)=>y.Field<float>(x)},
        {typeof(double),   (y,x)=>y.Field<double>(x)},
        {typeof(DateTime), (y,x)=>y.Field<DateTime>(x)},
        {typeof(TimeSpan), (y,x)=>y.Field<TimeSpan>(x)},
    };
