     // This column is nullable
     dtFinal.Columns.Add(new DataColumn("NullableColumn", typeof(double)));
     // This one isn't
     var col = new DataColumn("NotNullableColumn", typeof(double));
     col.AllowDBNull = false;
     dtFinal.Columns.Add(col);
