    if (_session.Connection.State == System.Data.ConnectionState.Open)
                    {
                        _session.Connection.Close();
                        _session.Connection.Open();
                    }
                    else if (_session.Connection.State == System.Data.ConnectionState.Closed)
                    {                    
                        _session.Connection.Open();
                    }
    
    result = _session.CreateCriteria<T>().List<T>();
                                
                
