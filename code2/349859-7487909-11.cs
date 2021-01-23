    var sourceFileDates = new DataTable();
    sourceFileDates.Columns.Add("Value", typeof(DateTime));
    foreach (DateTime file in job.sourceFiles)
    {
        sourceFileDates.Rows.Add(file);
    }
    selectRunCommand.Parameters.Add(new SqlParameter {
        ParameterName = "@SourceFileDates", 
        Value = sourceFileDates,
        SqlDbType = SqlDbType.Structured
    });
