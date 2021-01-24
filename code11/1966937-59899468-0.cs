    var query = memberModels.GroupJoin(emailModels, m => m.Id, e => e.Id, (m, emailCollection) => new
                {
                    FName= m.FName,
                    LName = m.LName,
                    MobileNumber = m.MobileNumber,
                    LandlineNumber = m.LandlineNumber,
                    WorkNumber = m.WorkNumber,
                    emailCollection = emailCollection
                    //emails = string.Join(", ", emailCollection.ToList().Select(e => e.EmailAddress) ).ToList() // you can not use string.Join directly on query, so need to do either ToList or AsEnumerable.
                }).AsEnumerable().Select(a => new 
                {
                    FName = a.FName,
                    LName = a.LName,
                    MobileNumber = a.MobileNumber,
                    LandlineNumber = a.LandlineNumber,
                    WorkNumber = a.WorkNumber,
                    EmailAddress = string.Join(", ", a.emailCollection.Select(e => e.EmailAddress))
                });
    dgReports.ItemsSource = query.ToList(); // just assign query to ItemSource if dgReports.ItemSource accepts Enumberable (like dgReports.ItemSource = query)
