    IEnumerable<DataRow> result = (from e in actual.Elements
                                  select new DataRow
                                  {
                                      Key = e.Key,
                                      ValueNumber = e.Value.ValueNumber,
                                      ValueString = e.Value.ValueString,
                                      ValueBinary = e.Value.ValueBinary,
                                      ValueDateTime = e.Value.ValueDateTime
                                  }).AsEnumerable();
    DataTable dt = Result.CopyToDataTable(Result);
