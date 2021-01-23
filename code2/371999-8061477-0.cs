          private void Export_To_Excel(GridView dgExport)
            {
                try
                {
                    string strFileName = String.Empty, strFilePath= String.Empty;
                    //Path where you decide where your excel saved
                    strFilePath = Server.MapPath("~/App_Data/Example.xls");
                    
                    System.IO.StringWriter oStringWriter =new StringWriter();
                    System.Web.UI.HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);
                    StreamWriter objStreamWriter;
                    string strStyle =@" .text { mso-number-format:\@; }
                    ";
                    objStreamWriter = File.AppendText(strFilePath);
                    dgExport.RenderControl(oHtmlTextWriter);
                    objStreamWriter.WriteLine(strStyle);
                    objStreamWriter.WriteLine(oStringWriter.ToString());
                    objStreamWriter.Close();
                    string strScript = "<script language=JavaScript>window.open('../Excel/" + "ExcelFileName" +".xls','dn','width=1,height=1,toolbar=no,top=300,left=400,right=1,scrollbars=no,locaton=1,resizable=1');</script>";
                    if(!Page.IsStartupScriptRegistered("clientScript"))
                    {
                     Page.RegisterStartupScript("clientScript", strScript);
                    }
                }
                catch(Exception)
                {
               
                }
            }
