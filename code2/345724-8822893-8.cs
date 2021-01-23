    void SqlMapper.IDynamicParameters.AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            if (templates != null)
            {
                foreach (var template in templates)
                {
                    var newIdent = identity.ForDynamicParameters(template.GetType());
                    Action<IDbCommand, object> appender;
                    lock (paramReaderCache)
                    {
                        if (!paramReaderCache.TryGetValue(newIdent, out appender))
                        {
                            appender = SqlMapper.CreateParamInfoGenerator(newIdent);
                            paramReaderCache[newIdent] = appender;
                        }
                    }
                    appender(command, template);
                }
            }
            foreach (var param in parameters.Values)
            {
                string name = Clean(param.Name);
                bool add = !((Oracle.DataAccess.Client.OracleCommand)command).Parameters.Contains(name);
                Oracle.DataAccess.Client.OracleParameter p;
                if(add)
                {
                    p = ((Oracle.DataAccess.Client.OracleCommand)command).CreateParameter();
                    p.ParameterName = name;
                } else
                {
                    p = ((Oracle.DataAccess.Client.OracleCommand)command).Parameters[name];
                }
                var val = param.Value;
                p.Value = val ?? DBNull.Value;
                p.Direction = param.ParameterDirection;
                var s = val as string;
                if (s != null)
                {
                    if (s.Length <= 4000)
                    {
                        p.Size = 4000;
                    }
                }
                if (param.Size != null)
                {
                    p.Size = param.Size.Value;
                }
                if (param.DbType != null)
                {
                    p.DbType = param.DbType.Value;    
                }
                if (add)
                {
                    if (param.DbType != null && param.DbType == DbType.Object)
                    {
                        p.OracleDbType = Oracle.DataAccess.Client.OracleDbType.RefCursor;
                        ((Oracle.DataAccess.Client.OracleCommand)command).Parameters.Add(p);
                    }
                    else
                    {
                        ((Oracle.DataAccess.Client.OracleCommand)command).Parameters.Add(p);
                    }                       
                }
                param.AttachedParam = p;
            }
        }
