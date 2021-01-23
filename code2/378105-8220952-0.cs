    DataTable grades = dataSet.Tables["Grades"];
    EnumerableRowCollection<DataRow> query = from grade in grades.AsEnumerable()
                                             where grade.Field<string>("Remarks") == "Failed"
                                             select grade;
    DataView view = query.AsDataView();
