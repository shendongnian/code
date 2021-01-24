      DateTime dateTime = DateTime.ParseExact(date, format, null);
            
         
            int year = Int32.Parse(dateTime.ToString("yyyy"));
            int month=Int32.Parse(dateTime.ToString("MM"));
            int day = Int32.Parse(dateTime.ToString("dd"));
            var toDate = new DateTime(year, month, day);
