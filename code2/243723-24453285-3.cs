    public class RechargeMobileViewModel
        {
            public string CustomerFullName { get; set; }
            public string TelecomSubscriber { get; set; }
            public int TotalAmount { get; set; }
            public string MobileNumber { get; set; }
            public int Month { get; set; }
            public List<SelectListItem> getAllDaysList { get; set; }
     
            // Define the list which you have to show in Drop down List
            public List<SelectListItem> getAllWeekDaysList()
            {
                List<SelectListItem> myList = new List<SelectListItem>();
                var data = new[]{
                     new SelectListItem{ Value="1",Text="Monday"},
                     new SelectListItem{ Value="2",Text="Tuesday"},
                     new SelectListItem{ Value="3",Text="Wednesday"},
                     new SelectListItem{ Value="4",Text="Thrusday"},
                     new SelectListItem{ Value="5",Text="Friday"},
                     new SelectListItem{ Value="6",Text="Saturday"},
                     new SelectListItem{ Value="7",Text="Sunday"},
                 };
                myList = data.ToList();
                return myList;
            }
    }
