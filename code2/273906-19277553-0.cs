        private EntityFrameworkEntities _modelInstance;
        protected override void Load()
        {
            bool retry = false;
            if (!TryLoad(out retry))
            {
                if (retry)
                {
                    AddColumnToTableInDatabase();
                    TryLoad(out retry);
                }
            }
        }
        private bool TryLoad(out bool retry)
        {
            bool success = false;
            retry = false;
            using (_modelInstance = new EntityFrameworkEntities())
            {
                _modelInstance.Connection.Open();
                var yourQuery = from entity in _modelInstance.Entitys
                                   select entity;
                try
                {
                    foreach (Entity entity in yourQuery)
                    {
                        var vm = new EntityViewModel(entity, this);
                        base.Children.Add(vm);
                    }
                    success = true;
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                        ex = ex.InnerException;
                    if (ex.Message.ToLower().Contains("no such column") && ex.Message.Split(new char[] { '.' })[1].Equals("Country_ID"))
                        retry = true;
                    log.Error(ex.Message, ex);
                }
            }
            return success;
        }
        private bool AddColumnToTableInDatabase()
        {
            bool success = false;
            StringBuilder sql = new StringBuilder(@"ALTER TABLE [Entity] ADD COLUMN [Country_ID] [text] NULL");
            using (_modelInstance = new EntityFrameworkEntities())
            {
                _modelInstance.Connection.Open();
                var connection = (_modelInstance.Connection as EntityConnection).StoreConnection as SQLiteConnection;
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = sql.ToString();
                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex.Message, ex);
                        transaction.Rollback();
                    }
                }
            }
            return success;
        }
