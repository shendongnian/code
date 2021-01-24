    public ActionResult MyAction(int id = 0)
            {
                var model = GetReport(id);
    
                return ReportView(model);
            }
    private ReportViewModel(int id)
    {
       // Get Report from Database Where Id = id
       // Populate ViewModel from the database data
       // Return reportViewModel;
    }
