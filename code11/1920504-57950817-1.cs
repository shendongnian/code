    using DevExpress.XtraReports.Parameters;
    using DevExpress.XtraReports.UI;
    // ... 
    
    public enum Gender { Male, Female }
    
    // Create a report instance. 
    XtraReport report = new XtraReport();
    
    // Create a new parameter. 
    Parameter param = new Parameter();
    
    // Specify required properties. 
    param.Name = "GenderParameter";
    param.Type = typeof(Gender);
    param.Visible = true;
    
    //Add the parameter to the report. 
    report.Parameters.Add(param);
