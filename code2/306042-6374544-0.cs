     if (adress!= null)
     {
        zipcode = adress.zipcode
        
        //if the following are null means this is first time call
        if (!(string.IsNullOrEmpty(_loadedZipcode)) && _address != null)
        {
        }
        else
        {
          return false;
        }
     }
     else
     {
       return false;
     }
                   
