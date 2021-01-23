            ExchangeService _service = new ExchangeService(ExchangeVersion.Exchange2010_SP2);
            //CREDENTIALS OF AN ACCOUNT WHICH HAS READ ACCESS TO THE CALENDAR YOU NEED
            _service.Credentials = new WebCredentials(username, password);
            _service.Url = new Uri(serviceURL);
            
            SearchFilter.SearchFilterCollection searchFilter = new SearchFilter.SearchFilterCollection();
            searchFilter.Add(new SearchFilter.IsGreaterThanOrEqualTo(AppointmentSchema.Start, DateTime.Now.AddDays(-1)));
            searchFilter.Add(new SearchFilter.IsLessThanOrEqualTo(AppointmentSchema.Start, DateTime.Now.AddDays(2)));
            ItemView view = new ItemView(50);
            view.PropertySet = new PropertySet(BasePropertySet.IdOnly, AppointmentSchema.Subject, AppointmentSchema.Start, AppointmentSchema.AppointmentType, AppointmentSchema.End);
            
            //THIS NEXT LINE!!!
            var calendarSearch = new FolderId(WellKnownFolderName.Calendar, new Mailbox("email@ofsomemailbox.com"));
            var appointments = _service.FindItems(calendarSearch, searchFilter, view);
