+--------+-----------------------------------+--------------------------------------------+
|        | DoWork                            | ReportProgress                             |
+--------+-----------------------------------+--------------------------------------------+
| 1      | Populate values of Obj with row 1 |                                            |
+--------+-----------------------------------+--------------------------------------------+
| 2      | Wait 100 ms                       |                                            |
+--------+-----------------------------------+--------------------------------------------+
| 3      | Dispatch ReportProgress           |                                            |
+--------+-----------------------------------+--------------------------------------------+
| 4      | Populate values of Obj with row 2 |                                            |
+--------+-----------------------------------+--------------------------------------------+
| 5      | Wait 100 ms                       | Add a row with values of Obj, now at Row 2 |
+--------+-----------------------------------+--------------------------------------------+
| 6      | Dispatch ReportProgress           |                                            |
+--------+-----------------------------------+--------------------------------------------+
| 7      | Populate values of Obj with row 3 |                                            |
+--------+-----------------------------------+--------------------------------------------+
| 8      | Wait 100 ms                       | Add a row with values of Obj, now at Row 3 |
+--------+-----------------------------------+--------------------------------------------+
| 9      | Dispatch ReportProgress           |                                            |
+--------+-----------------------------------+--------------------------------------------+
| 10     | Populate values of Obj with row 4 |                                            |
+--------+-----------------------------------+--------------------------------------------+
| 11     | Wait 100 ms                       | Add a row with values of Obj, now at Row 4 |
+--------+-----------------------------------+--------------------------------------------+
| 12     | Dispatch ReportProgress           |                                            |
+--------+-----------------------------------+--------------------------------------------+
| 13     | End of iteration, no more rows    | Add a row with values of Obj, now at Row 4 |
+--------+-----------------------------------+--------------------------------------------+
How to fix it?
The easiest way would be to use a new instance of `Obj` on each iteration. That way, that way each call to `ReportProgress` has its own instance which will not be changed.
In other words, something like the below assuming `RetrieveTableData` is a simple object requiring no parameters to its constructor. I'm deliberately keeping to your original style rather than rewriting everything.. there are lots of issues we could talk about here, code style, names of variables, but it is not directly relevant to the problem...
while (reader.Read())
{
    var Obj = new RetriveTableData(); // create a new instance
    Obj.uid = reader["id"].ToString();
    Obj.iss_type = reader["issue_type"].ToString();
    ...
We would then no longer need this line at the top of the method; the point is to change the scope of `Obj` so we do not reuse it on each iteration.
    RetriveTableData Obj = (RetriveTableData)e.Argument;
`Thread.Sleep(100)` would no longer be needed either.
To tackle your additional aim of creating the data rows in the complete event rather than the progress event, you could collect these individual `RetrieveTableData` objects into a `List<RetrieveTableData>`, and pass that to your `RunWorkerCompleted` event handler via `e.Result` on the `DoWorkEventArgs`.
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.backgroundworker.reportprogress?view=netframework-4.8
