     var orderedList2 = myList.OrderByDescending(x =>
        {
            DateTime dt;
           if( DateTime.TryParse(x.delivery, out dt))
               return dt;
            return DateTime.MinValue;
        });
