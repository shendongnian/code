    <%@ WebHandler Language="C#" Class="excel" %>
    
    using System;
    using System.Web;
    using OfficeOpenXml;
    using OfficeOpenXml.Drawing;
    using OfficeOpenXml.Style;
    using System.Drawing;
    using System.Data;
    
    
    public class excel : IHttpHandler {
        
        public void ProcessRequest (HttpContext context) {
            using (ExcelPackage pck = new ExcelPackage())
            {
                int id = int.Parse(context.Request.QueryString["id"]);
                DateTime now = DateTime.Now;
                
                //get and format datatable
                Project proj = new Project(id);
                DataTable items = proj.getItemsDataTable();
    
                items = PmFunctions.prettyDates(items);
                items = PmFunctions.prettyMoney(items);
                
                //new worksheet
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add(proj.getTitle());
                
                //load data
                ws.Cells["A1"].Value = proj.getTitle();
                ws.Cells["A1"].Style.Font.Size = 20;
                
                ws.Cells["A2"].Value = "Report Date:";
                ws.Cells["C2"].Value = now.ToShortDateString();
    
                ws.Cells["A4"].Value = "Estimate Total:";
                ws.Cells["C4"].Value = String.Format("{0:C}", proj.getProjectEstimate());
    
                ws.Cells["A5"].Value = "Actual Total:";
                ws.Cells["C5"].Value = String.Format("{0:C}", proj.getProjectTotal());
                
                ws.Cells["A7"].LoadFromDataTable(items, true);
                
                //Stylings
                using (ExcelRange rng = ws.Cells["A7:J7"])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                    rng.Style.Font.Color.SetColor(Color.White);
                }
    
                
    
                //Write to the response
                context.Response.Clear();
                context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                context.Response.AddHeader("content-disposition", "attachment;  filename=" + proj.getTitle() + " Report - " + now.ToShortDateString() + ".xlsx");
                context.Response.BinaryWrite(pck.GetAsByteArray());
            }
        }
     
        public bool IsReusable {
            get {
                return false;
            }
        }
    }
