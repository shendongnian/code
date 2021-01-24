                DataTable dt = new DataTable();
                dt.Columns.Add("EMP_ID", typeof(string));
                dt.Columns.Add("EMP_NAME", typeof(string));
                dt.Columns.Add("DEPARTMENT_NAME", typeof(string));
                dt.Columns.Add("DESIGNATION", typeof(string));
                dt.Columns.Add("BRANCH", typeof(string));
                dt.Columns.Add("AMOUNT", typeof(double));
    
                Byte[] bytes = DataExporter.GetBytes(dt);
    
                Response.ClearHeaders();
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-length", bytes.Length.ToString());
                Response.AddHeader("content-disposition", "attachment; filename=AddDataUpload.xlsx");
                Response.OutputStream.Write(bytes, 0, bytes.Length);
                Response.Flush();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
