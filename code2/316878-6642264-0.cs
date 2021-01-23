    SQLiteCommand command = cnn.CreateCommand();
    command.CommandText = String.Format("INSERT INTO registry" +
            "(NameDoc, YearDoc, MonthDoc, DayDoc, RawDoc) VALUES" +
            "('{0}', '{1}', '{2}', '{3}', @0)",
            txtNameDoc.Text, numUDYear.Value, numUDD.Value, numUDD.Value);
    SQLiteParameter parameter = new Parameter("@0", System.Data.DbType.Binary);
    parameter.Value = rawDoc;
    command.Parameters.Add(parameter);
    command.ExecuteNonQuery();
