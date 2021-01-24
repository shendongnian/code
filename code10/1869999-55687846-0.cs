    public List<InspectionReport> GetInspectionReportDetails(int InspectionReportID)
        {
            var List= this.Database.SqlQuery<InspectionReport>("GetInspectionReportDetails @InspectionReportID", InspectionReportID).ToList();
            return List;
        }
