    DateTime time1 = DateTime.Parse("08:00:00");
     Datetime d=DateTime.ParseExact(pRow["STATUSIN"].ToString(), "hh:mm:ss", CultureInfo.InvariantCulture);
       if (d > time1)
       {
          pRow["LATECOME"] =d - time1.ToString();
       }
 
   
            
            
