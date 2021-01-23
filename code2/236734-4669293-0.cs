            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=adressenbestand.csv");
            Response.ContentType = "text/csv";
            //write the header
            Response.Write(String.Format("{0},{1},{2},{3}", CMSMessages.EmailAddress, CMSMessages.Gender, CMSMessages.FirstName, CMSMessages.LastName));
            //write every subscriber to the file
            var resourceManager = new ResourceManager(typeof(CMSMessages));
            foreach (var record in filterRecords.Select(x => x.First().Subscriber))
            {
                Response.Write(String.Format("{0},{1},{2},{3}", record.EmailAddress, record.Gender.HasValue ? resourceManager.GetString(record.Gender.ToString()) : "", record.FirstName, record.LastName));
            }
            Response.End();
