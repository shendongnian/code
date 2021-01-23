    using System;
    using System.Data;
    using System.Configuration;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using Spire;
    using Spire.Xls;
    
    namespace SD.Reval.Admin.Services
    {
        public class ExportHandler   : IHttpHandler
        {
            virtual public bool IsReusable
            {
                get { return true; }
            }
    
    
            virtual  public void ProcessRequest(HttpContext context)
            {
                try
                {
                    
                    Workbook workbook = new Workbook();
                    Worksheet worksheet;
    
                    int counter = 0;
                    string methodName = HttpContext.Current.Request.QueryString["methodName"];
                    string fileName = HttpContext.Current.Request.QueryString["fileName"];
                    string parameters = HttpContext.Current.Request.QueryString["params"];
                    if (parameters == null)
                        parameters = HttpContext.Current.Request.Form["params"];
    
                    int workSheetCount = workbook.Worksheets.Count;
                    string tableName = string.Empty ;
    
                    if (methodName.Length > 0 && fileName.Length > 0)
                    {
    
                        DataSet dataSet = (DataSet)ServiceInterface.InternalGenericInvoke(methodName, parameters);
    
                        foreach (DataTable dt in dataSet.Tables)
                        {
                            if (dt.Columns.Count > 0)
                            {
                                tableName = dt.TableName ;
    
                                if (counter >= workSheetCount)
                                    worksheet=workbook.Worksheets.Add(tableName);
                                else
                                {
                                    worksheet = workbook.Worksheets[counter];
                                    worksheet.Name = tableName;
                                }
                                    
    
                                worksheet.InsertDataTable(dt, true, 4, 1, -1, -1);
                                counter++;
                                worksheet.AllocatedRange.AutoFitColumns();
                                worksheet.AllocatedRange.AutoFitRows();
                                worksheet.Pictures.Add(1, 1, SD.Reval.Admin.Services.ResourceFile.logo_reval );
                                
                                //Sets header style
                                CellStyle styleHeader = worksheet.Rows[0].Style;
                                styleHeader.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Thin;
                                styleHeader.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Thin;
                                styleHeader.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Thin;
                                styleHeader.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Thin;
                                styleHeader.VerticalAlignment = VerticalAlignType.Center;
                                styleHeader.KnownColor = ExcelColors.Green;
                                styleHeader.Font.KnownColor = ExcelColors.White;
                                styleHeader.Font.IsBold = true;
                            }
    
                        }
                        fileName = fileName + ".xls";
                        
                        workbook.SaveToHttpResponse(fileName, context.Response);
                         
                        context.Response.Buffer = true;
                        context.Response.ContentType = "application/x-msdownload";
                        context.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName  );
                    }
    
        
                }
                catch (Exception  ex)
                {
                    Log.WriteLog(ex);
                    throw new ApplicationException("The epxport process failed", ex);
                }
                finally
                {
    
                }
            }
    
        }
    }
