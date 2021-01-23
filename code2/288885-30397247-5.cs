    private static void LogSqlErrors(Exception ex)
    {
        if (ex == null)
            return;
        var sqlEx = ex as SqlException;
        if (sqlEx != null && sqlEx.Errors != null && sqlEx.Errors.Count > 0)
        {
            var sqlErrs = new StringBuilder();
            sqlErrs.AppendFormat("SqlException contains {0} SQL error(s):", sqlEx.Errors.Count)
                .AppendLine();
            foreach (SqlError err in sqlEx.Errors)
            {
                sqlErrs.AppendLine("--------------------------------")
                    .AppendFormat("Msg {0}, Level {1}, State {2}, Procedure '{4}', Line {5}",
                        err.Number, err.Class, err.State, err.Procedure, err.LineNumber)
                    .AppendLine()
                    .AppendLine(err.Message);
            }
            Logger.Warn(sqlErrs.ToString());
        }
        LogSqlErrors(ex.InnerException);
    }
