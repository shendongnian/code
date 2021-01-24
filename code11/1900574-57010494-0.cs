    public ActionResult GenerateCsvReportByClient(int clientId, DateTime? dateFrom , DateTime? dateTo)
        {
            List<ExportCSV> mainList = new List<ExportCSV>();
            var tableName = "";
            IQueryable query = _fanService.GetExportByClientId(out tableName ,clientId, dateFrom, dateTo);
            //var data = query.OfType<ExportCSV>().ToList();
            if(tableName == "ExportCSV")
            {
                var datalist = query.OfType<ExportCSV>().ToList();
                mainList = datalist;
            }
            else
            {
                var datalist = query.OfType<ExportCSV2>().ToList();
                mainList = datalist.Select(x => new ExportCSV{
                    LinkedInId = x.LinkedInId,
                    SNUrl = x.SNUrl,
                    Fullname = x.Fullname,
                    Firstname = x.Firstname,
                    Lastname = x.Lastname,
                    Organization1 = x.Organization1,
                    JobTitle = x.JobTitle,
                    Email = x.Email,
                    ExperienceDescr = x.ExperienceDescr,
                    ProfileLocation = x.ProfileLocation,
                    OrganizationDescription1 = x.OrganizationDescription1,
                    Organization1Industry = x.Organization1Industry,
                    ....
                    }
    }
