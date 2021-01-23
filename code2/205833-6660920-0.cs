    try
                {
                    if (_tasksAdapter.Connection.State != ConnectionState.Open)
                        _tasksAdapter.Connection.Open();
                    
                    _tasksAdapter.InsertNew(_partitionedFile.Uid, _partitionedFile.Checksum);
                    _dbId = (int)_tasksAdapter.GetIdentity().Value;
                }
                finally
                {                    
                    if (_tasksAdapter.Connection.State != ConnectionState.Closed)
                        _tasksAdapter.Connection.Close();
                }
