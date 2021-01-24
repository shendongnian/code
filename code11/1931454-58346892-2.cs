public static List<Objects.Logs.GenericLog> GetLogs(int entityId = int.MinValue, 
    int logLevelId = int.MinValue, DateTime startDate = default(DateTime), 
    DateTime endDate = default(DateTime))
{
    using(var db = CORAContext.GetCORAContext())
    {
        return db.GenericLog
            .Where(i => startDate == default(DateTime) || i.LogDateTime >= startDate)
            .Where(i => endDate == default(DateTime) || i.LogDateTime <= endDate)
            .Where(i => entityId == int.MinValue || i.EntityId == entityId)
            .Where(i => logLevelId == int.MinValue || i.LogLevelId == logLevelId)
            .Select(i => new Objects.Logs.GenericLog
            {
                EntityId = i.FkEntityId,
                LogSourceCode = i.FkLogSourceCode,
                LogLevelId = i.FkLogLevelId,
                LogDateTime = i.LogDateTime,
                LogId = i.PkLogId,
                Message = i.Message
            }).ToList();
    }
}
