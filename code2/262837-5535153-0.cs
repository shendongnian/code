    public static void SetWorkSheetQuery(Microsoft.Office.Interop.Excel.Worksheet ws, EntityQuery q)
     {
                        var cp = GetCustomProperty(ws,"query");
                        if (cp == null)
                            ws.CustomProperties.Add("query", q.ToJson());
                        else cp.Value = q.ToJson();
     }
