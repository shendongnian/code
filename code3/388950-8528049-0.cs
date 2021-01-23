      var test= = firmaer.Where(x => x.CVR_nummeruser.UserName).FirstOrDefault();
     
      if(test == null)
      {
      model.FirmaNavn = "Missing";
      }
      else
      {
        model.FirmaNavn =(string)test;
      }
