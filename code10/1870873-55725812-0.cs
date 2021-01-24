     public class AddInspectionReportViewModel
                {
                    [DataType(DataType.Upload)]
                    public HttpPostedFileBase File { get; set; }
                    public InspectionReport InspectionReport { get; set; }
                }
