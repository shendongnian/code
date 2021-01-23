    private Microsoft.Office.Interop.Word.ApplicationClass MSdoc;       
           
            //Use for the parameter whose type are not known or say Missing
            object Unknown = Type.Missing;
    
      private void word2PDF(object Source, object Target)
            {   //Creating the instance of Word Application          
           if (MSdoc == null)MSdoc = new Microsoft.Office.Interop.Word.ApplicationClass();
               
                try
                {  
                    MSdoc.Visible = false;               
                    MSdoc.Documents.Open(ref Source, ref Unknown,
                         ref Unknown, ref Unknown, ref Unknown,
                         ref Unknown, ref Unknown, ref Unknown,
                         ref Unknown, ref Unknown, ref Unknown,
                         ref Unknown, ref Unknown, ref Unknown, ref Unknown, ref Unknown);
                    MSdoc.Application.Visible = false;
                    MSdoc.WindowState = Microsoft.Office.Interop.Word.WdWindowState.wdWindowStateMinimize;               
                                                   
                    object format = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF;
                                   
                    MSdoc.ActiveDocument.SaveAs(ref Target, ref format,
                            ref Unknown, ref Unknown, ref Unknown,
                            ref Unknown, ref Unknown, ref Unknown,
                            ref Unknown, ref Unknown, ref Unknown,
                            ref Unknown, ref Unknown, ref Unknown,
                           ref Unknown, ref Unknown);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    if (MSdoc != null)
                    {
                        MSdoc.Documents.Close(ref Unknown, ref Unknown, ref Unknown);
                        // for closing the application
                        MSdoc.Quit(ref Unknown, ref Unknown, ref Unknown);
                    }
                }
            }
    
     
    
    Prerequisite:
    
    MS word2007 with (Primary Interoperability assembly  will be installed by default).
