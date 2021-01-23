     Microsoft.ReportingServices.QueryDesigners
     Microsoft.ReportingServices.Designer.Controls
     Microsoft.ReportingServices.RdlObjectModel
     Microsoft.ReportingServices.ReportDesign.Common
     Microsoft.ReportingServices.RichText
     Microsoft.ReportingServices.RPLObjectModel
 
      private Report LoadReportTemplate()
      {
            const string docPath = "template.rdl";//path for your template report
            using (var fs = new FileStream(docPath, FileMode.Open))
            {
                var report = Report.Load(fs);
                return report;
            }
      }
