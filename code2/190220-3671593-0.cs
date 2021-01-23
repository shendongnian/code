           pkg.SrcConn.Unicode = (fileFormat == FileFormat.UNICODE);
           pkg.SrcConn.ConnectionString = srcFile;
           pkg.SrcConn.Columns.Add().DataType = dataType;
           pkg.SrcConn.Columns[0].ColumnType = "Delimited";
           pkg.SrcConn.ColumnNamesInFirstDataRow = false;
           pkg.SrcConn.ColumnDelimiter = ",";
           pkg.SrcConn.RowDelimiter = "\r\n";
           pkg.SrcConn.TextQualifier = "\"";
           pkg.SrcConn.Columns[0].TextQualified = testObject.textQualified;
           if (!pkg.Source.OutputColumnExists("col0"))
           {
               pkg.Source.InsertOutputColumn("col0");
           }
           pkg.Source.SetOutputColumnDataTypeProperties("col0", dataType, testObject.length, testObject.precision, testObject.scale, testObject.codePage);
