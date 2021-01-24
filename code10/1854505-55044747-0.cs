    static IQueryable<AuditLog> Where(this IQueryable<AuditLog> auditLogs,
           int year, int month, int day)
    {
         // zero value parameters: do not use. so
         // 2011 11 00: all days of November 2011
         // 2011 00 14: every 14th day of every month of 2011
         if (year != 0)
         {
             if (month != 0)
             {
                 if (day != 0)
                 {  // use parameters year, month, day
                    return auditLogs.Where(auditLog =>
                           auditLog.ChangeTime.Year == year &&
                           auditLog.ChangeTime.Month == month &&
                           auditLog.ChangeTime.Day == day);
                 }
                 else
                 {  // use parameters year, month
                    return auditLogs.Where(auditLog =>
                           auditLog.ChangeTime.Year == year &&
                           auditLog.ChangeTime.Month == month);
                 }
            }
            else
            {   // don't use Month
                if (day != 0)
                {   // use parameters year, day
                    return auditLogs.Where(auditLog =>
                           auditLog.ChangeTime.Year == year &&
                           auditLog.ChangeTime.Day == day);
                 }
                 else
                 {  // use parameter year
                    return auditLogs.Where(auditLog => auditLog.ChangeTime.Year;
                 }
            }
        }
        else
            ... etc, don't use parameter day        
    }
