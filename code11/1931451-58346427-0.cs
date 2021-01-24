        public static List<Objects.Logs.GenericLog> GetLogs(int entityId, int logLevelId, DateTime startDate, DateTime endDate)
            {
                var logsList = new List<Objects.Logs.GenericLog>();
        
                using(var db = CORAContext.GetCORAContext())
                {
        
                    var query = (from i in db.GenericLog select  new Objects.Logs.GenericLog()
                    {
                        EntityId = i.FkEntityId,
                        LogSourceCode = i.FkLogSourceCode,
                        LogLevelId = i.FkLogLevelId,
                        LogDateTime = i.LogDateTime,
                        LogId = i.PkLogId,
                        Message = i.Message
                    });
                    if(someCondition) {
                         query = query.Where(i => i.LogDateTime >= startDate && i.LogDateTime <= endDate)
                    }
                    query = query.Where(i => i.EntityId == entityId || i.EntityId == null)
                    query = query.Where(i => i.LogLevelId == logLevelId || i.EntityId == null)
                    logsList = query.ToList();
        
                }
        
                return logsList;
            }
