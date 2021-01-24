    public class Class2bTested
    {
        IGenerateReportService _IGenerateReportService;
        public (IGenerateReportService IIGenerateReportService)
        {
             _IIGenerateReportService=IIGenerateReportService;
        }
                    
        public static byte[] GenerateFinanceReport(long financeId, long userId, string currentLanguage, ReportDataVO reportDataVO, string reportName)
        {
            var parameterValues = SetStandardParameters(userId, currentLanguage, reportDataVO);
            var paramFinanceId = new ParameterValue
            {
                Value = financeId.ToString(),
                Name = ParamFinanceId
            };
            parameterValues.Add(paramFinanceId );
            return _IGenerateReportService.GenerateReport(reportDataVO, parameterValues, reportName);
         }
     }
