    class DynamicParametersWithTVP : SqlMapper.IDynamicParameters
    {
        private Dictionary<string, TVPData> _tvpParams;
        private DynamicParameters _params;
        public DynamicParametersWithTVP()
        {
            _tvpParams = new Dictionary<string, TVPData>();
            _params = new DynamicParameters();
        }
        public void Add( string name, object value = null, DbType? dbType = null, ParameterDirection? direction = null, int? size = null )
        {
            _params.Add( name, value, dbType, direction, size );
        }
        public void AddTVPString( string name, IEnumerable<string> values )
        {
            var metadata = new[] {
                new SqlMetaData( "one", SqlDbType.VarChar, 256)
            };
            var data = new TVPData
            {
                Data = values,
                MetaData = metadata,
                Name = name,
                Type = "stringlist_tbltype",
                SetData = ( rec, s ) => rec.SetString( 0, (string)s ),
            };
            _tvpParams.Add( name, data );
        }
        public void AddParameters( IDbCommand command, SqlMapper.Identity identity )
        {
            //Adds the regular parameters, then adds any tvp parameters
            ((SqlMapper.IDynamicParameters)_params).AddParameters( command, identity );
            AddTVPCommands( command );
        }
        private void AddTVPCommands( IDbCommand command )
        {
            foreach (var o in _tvpParams) {
                AddTVPParam( command, o.Key, o.Value );
            }
        }
        private void AddTVPParam( IDbCommand command, string name, TVPData value )
        {
            var dataList = new List<SqlDataRecord>();
            if (value.Data != null) {
                foreach (var d in value.Data) {
                    var rec = new SqlDataRecord( value.MetaData );
                    value.SetData( rec, d ); //note: this only works for a one-column TVP
                    dataList.Add( rec );
                }
            }
            if (dataList.Count == 0) { //gotta make the value null if there isn't any data.
                dataList = null;
            }
            var p = ((SqlCommand)command).Parameters.Add( name, SqlDbType.Structured );
            p.Direction = ParameterDirection.Input;
            p.TypeName = value.Type;
            p.Value = dataList;
        }
        private class TVPData
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public SqlMetaData[] MetaData { get; set; }
            public IEnumerable Data { get; set; }
            public Action<SqlDataRecord, object> SetData { get; set; }
        }
    }
