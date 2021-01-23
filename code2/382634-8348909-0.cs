    public class ReportGeneratorWrapper
    {
         private ReportGenerator m_InnerReportGenerator;
         public PreviewDocument Preview
         {
             get
             {
                 return m_InnerReportGenerator;
             }
             set
             {
                 if (IsNT6OrAbove)
                     value.Render();
                 m_InnerReportGenerator = value;
             }
         }
    }
