    var services = DictionaryObject.GetDictionaryValidatedByDate<ServiceInfo>(DictionaryType.REF_SERVICE, DateTime.Now);
    
    var anotherService =  DictionaryObject.GetDictionaryValidatedByDate<ServiceInfo>(DictionaryType.REF_SERVICE, DateTime.Now);;
    
    anotherService.RemoveAll(p =>                
        {                   
            if (p.Model.mainService == false || p.Model.mainService == true)
            {
               return true;
            }
            return false;
        });
