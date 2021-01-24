    class Data
    {
        public Data( Int32 id, String description, Int32 state, Int32 res )
        {
            this.Id = id;
            this.Description = description;
            this.State = state;
            this.Res = res;
        }
        public Int32 Id { get; }
        public String Description { get; }
        public Int32 State { get; }
        public Int32 Res { get; }
    }
    public static List<Data> ParseData( String input )
    {
        RegEx r = new Regex( @"\{\s*(\d+)\s*,\s*'(.*?)'\s*,\s*(\d+)\s*,\s*(\d+)\s*\}" );
        List<Data> list = new List<Data>();
        Match m = r.Match( input );
        while( m.Success )
        {
            Int32  id    = Int32.Parse( m.Groups[1].Value, NumberStyles.Integer, CultureInfo.InvariantCulture );
            String desc  = m.Groups[2].Value;
            Int32  state = Int32.Parse( m.Groups[3].Value, NumberStyles.Integer, CultureInfo.InvariantCulture );
            Int32  res   = Int32.Parse( m.Groups[4].Value, NumberStyles.Integer, CultureInfo.InvariantCulture );
            Data d = new Data( id, desc, state, res );
            list.Add( d );
            m = m.NextMatch();
        }
        return list;
    }
