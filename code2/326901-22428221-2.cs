    internal class TableTypeDynamicParam : SqlMapper.IDynamicParameters {
        protected readonly List<object> Lst = new List<object>();
        protected SqlCommand Cmd;
        public void Add(DataTable dt) {
            if(dt != null)
                Lst.Add(dt);
        }
        public void Add(DataSet ds) {
            if(ds != null)
                foreach(DataTable dt in ds.Tables) {
                    Lst.Add(dt);
                }
        }
        public void Add(string name, object value = null, SqlDbType? dbType = null, ParameterDirection direction = ParameterDirection.Input, int? size = null) {
            var par = value != null ? new SqlParameter(name, value) : new SqlParameter(name, dbType);
            par.Direction = direction;
            if(size.HasValue)
                par.Size = size.Value;
            Lst.Add(par);
        }
        public void Add(SqlParameter par) {
            Lst.Add(par);
        }
        public void AddRange(IEnumerable<SqlParameter> pars) {
            if(pars != null)
                Lst.AddRange(pars);
        }
        public void AddParameters(IDbCommand command) {
            Cmd = (SqlCommand)command;
            foreach(var o in Lst) {
                var dt = o as DataTable;
                if(dt != null) {
                    var parameter = Cmd.Parameters.AddWithValue(dt.ExtendedProperties["parameterName"].ToString(), dt);
                    parameter.SqlDbType = SqlDbType.Structured;
                    parameter.TypeName = dt.TableName;
                } else {
                    var par = o as SqlParameter;
                    if(par != null)
                        Cmd.Parameters.Add(par);
                }
            }
        }
        public void AddParameters(IDbCommand command, SqlMapper.Identity identity) {
            AddParameters(command);
        }
        public T Get<T>(string name) {
            return (T)Cmd.Parameters[name].Value;
        }
        public ERPDictionay GetLst(ERPLst<SqlParameter> pars) {
            var dic = new ERPDictionay();
            if(pars != null) {
                dic.QtdItemsPageParameterName = pars.QtdItemsPageParameterName;
                dic.QtdItemsPage = pars.QtdItemsPage;
                dic.CurrentPageParameterName = pars.CurrentPageParameterName;
                dic.CurrentPage = pars.CurrentPage;
            };
            for(var i = 0; i < Cmd.Parameters.Count; i++) {
                var a = Cmd.Parameters[i];
                if (a.Direction != ParameterDirection.InputOutput && a.Direction != ParameterDirection.Output) continue;
                if(pars != null && a.ParameterName == pars.TotalItensDBParameterName) {
                    dic.TotalItensDB = Convert.ToInt32(Cmd.Parameters[i].Value);
                } else {
                    dic.Add(a.ParameterName, Cmd.Parameters[i].Value);
                }
            }
            return dic;
        }
    }
    internal class TableTypeDynamicParam<T> : TableTypeDynamicParam
    {
        private ERPLstInput<T> _lstItems;
        public void Add(ERPLstInput<T> lstItems)
        {
            if (lstItems != null)
                _lstItems = lstItems;
        }
        private static Dictionary<Type, SqlDbType> _typeMap;
        private static Dictionary<Type, SqlDbType> TypeMap
        {
            get
            {
                if (_typeMap != null)
                    return _typeMap;
                _typeMap = new Dictionary<Type, SqlDbType>();
                _typeMap[typeof(byte)] = SqlDbType.TinyInt;
                _typeMap[typeof(sbyte)] = SqlDbType.TinyInt;
                _typeMap[typeof(short)] = SqlDbType.SmallInt;
                _typeMap[typeof(ushort)] = SqlDbType.SmallInt;
                _typeMap[typeof(int)] = SqlDbType.Int;
                _typeMap[typeof(uint)] = SqlDbType.Int;
                _typeMap[typeof(long)] = SqlDbType.Int;
                _typeMap[typeof(ulong)] = SqlDbType.BigInt;
                _typeMap[typeof(float)] = SqlDbType.Float;
                _typeMap[typeof(double)] = SqlDbType.Float;
                _typeMap[typeof(decimal)] = SqlDbType.Decimal;
                _typeMap[typeof(bool)] = SqlDbType.Bit;
                _typeMap[typeof(string)] = SqlDbType.Text;
                _typeMap[typeof(char)] = SqlDbType.Char;
                _typeMap[typeof(Guid)] = SqlDbType.UniqueIdentifier;
                _typeMap[typeof(DateTime)] = SqlDbType.DateTime;
                _typeMap[typeof(DateTimeOffset)] = SqlDbType.DateTimeOffset;
                _typeMap[typeof(byte[])] = SqlDbType.Binary;
                _typeMap[typeof(byte?)] = SqlDbType.TinyInt;
                _typeMap[typeof(sbyte?)] = SqlDbType.TinyInt;
                _typeMap[typeof(short?)] = SqlDbType.SmallInt;
                _typeMap[typeof(ushort?)] = SqlDbType.SmallInt;
                _typeMap[typeof(int?)] = SqlDbType.Int;
                _typeMap[typeof(uint?)] = SqlDbType.Int;
                _typeMap[typeof(long?)] = SqlDbType.BigInt;
                _typeMap[typeof(ulong?)] = SqlDbType.BigInt;
                _typeMap[typeof(float?)] = SqlDbType.Float;
                _typeMap[typeof(double?)] = SqlDbType.Float;
                _typeMap[typeof(decimal?)] = SqlDbType.Decimal;
                _typeMap[typeof(bool?)] = SqlDbType.Bit;
                _typeMap[typeof(char?)] = SqlDbType.Char;
                _typeMap[typeof(Guid?)] = SqlDbType.UniqueIdentifier;
                _typeMap[typeof(DateTime?)] = SqlDbType.DateTime;
                _typeMap[typeof(DateTimeOffset?)] = SqlDbType.DateTimeOffset;
                return _typeMap;
            }
        }
        static SqlDbType GetSqlDBType(Type t) {
            return TypeMap[t];
        }
        void SetRecordValue(ref SqlDataRecord rec, string propertyName, object value, Type propertyType) {
            switch(propertyType.ToString()) {
                case "System.Int32":
                    rec.SetInt32(def.IndexOf(a=>a.Name == propertyName), (int)value);
                    break;
                case "System.Int64":
                    rec.SetInt64(def.IndexOf(a => a.Name == propertyName), (long)value);
                    break;
                case "System.Boolean":
                    rec.SetBoolean(def.IndexOf(a => a.Name == propertyName), (bool)value);
                    break;
                case "System.String":
                default:
                    rec.SetString(def.IndexOf(a => a.Name == propertyName), Convert.ToString(value));
                    break;
            }
        }
        private List<SqlMetaData> def;
        public new void AddParameters(IDbCommand command) {
            Cmd = (SqlCommand)command;
            foreach(var o in Lst) {
                var dt = o as DataTable;
                if(dt != null) {
                    var parameter = Cmd.Parameters.AddWithValue(dt.ExtendedProperties["parameterName"].ToString(), dt);
                    parameter.SqlDbType = SqlDbType.Structured;
                    parameter.TypeName = dt.TableName;
                } else {
                    var par = o as SqlParameter;
                    if(par != null)
                        Cmd.Parameters.Add(par);
                }
            }
            if (_lstItems != null)
            {
                var tableTypeList = new List<SqlDataRecord>();
                var first = _lstItems.FirstOrDefault();
                if (first != null)
                {
                    def = new List<SqlMetaData>();
                    int i = 0;
                    foreach (var prop in first.GetType().GetProperties())
                    {
                        def.Add(new SqlMetaData(prop.Name, GetSqlDBType(prop.PropertyType)));
                    }
                    foreach (var l in _lstItems)
                    {
                        var rec = new SqlDataRecord(def.ToArray());
                        foreach (var prop in first.GetType().GetProperties())
                        {
                            SetRecordValue(ref rec, prop.Name, prop.GetValue(l), prop.GetType());
                        }
                        tableTypeList.Add(rec);
                    }
                }
                var p = Cmd.Parameters.Add("@" + _lstItems.ParameterName.TrimStart('@'), SqlDbType.Structured);
                p.Direction = ParameterDirection.Input;
                p.TypeName = _lstItems.TableTypeName;
                if (null != first)
                    p.Value = tableTypeList;
                else
                    p.Value = DBNull.Value;
            }
        }
    }
