    private ReportDocument CrystalRpt;
        //Declaring these here and disposing in the Page_Unload event was the key.  Then the only other issue was the
        // limitations of Crystal 11 and simultaneous access to the rpt file.  I make a temp copy of the file and use that in the
        // method.  Then I delete the temp file in the unload event.
    
        private ReportDocument mySubRepDoc;
        private ReportClass ReportObject;
        private string tmpReportName;
    
        protected void Page_UnLoad(object sender, EventArgs e)
        {
    Try
    {
                CrystalReportViewer1.Dispose();
                CrystalReportViewer1 = null;
                CrystalRpt.Close();
                CrystalRpt.Dispose();
                CrystalRpt = null;
                mySubRepDoc.Close();
                mySubRepDoc.Dispose();
                mySubRepDoc = null;
                ReportObject.Close();
                ReportObject.Dispose();
                ReportObject = null;
                GC.Collect();
                File.Delete(tmpReportName);
    
    }
    catch
    { ...Error Handler }
        }
     
    
    
    protected void Page_Load(object sender, EventArgs e)
        {
            CrystalRpt = new ReportDocument();
            ConnectionInfo CrystalConn = new ConnectionInfo();
            TableLogOnInfo tblLogonInfo = new TableLogOnInfo();
            ReportObject = new ReportClass();
            
            TableLogOnInfo CrystalLogonInfo = new TableLogOnInfo();
            ParameterField CrystalParameter = new ParameterField();
            ParameterFields CrystalParameters = new ParameterFields();
            ParameterDiscreteValue CrystalParameterDV = new ParameterDiscreteValue();
    
            TableLogOnInfo ConInfo = new TableLogOnInfo();
            SubreportObject mySubReportObject;
            mySubRepDoc = new ReportDocument();
    
            //Report name is sent in querystring.
            string ReportName = Request.QueryString["ReportName"];
    
            // I did this because Crystal 11 only supports 3 simultaneous users accessing the report and 
            // we have up to 60 at any time.  This copies the actual rpt file to a temp rpt file.  The temp rpt
            // file is used and then is deleted in the Page_Unload event
    
            Random MyRandomNumber = new Random();
            tmpReportName = ReportName.Replace(".rpt", "").Replace(".ltr", "") + MyRandomNumber.Next().ToString() +".rpt";
            File.Copy(ReportName, tmpReportName, true);
     
            CrystalRpt.Load(tmpReportName);
