    public static class CompanyExtensions{
    
       public static CompanyDto ToCompanyDto(this Company c){
    
         var cDto = new CompanyDto();
         
         cDto.Name = c.Name;
         cDto.Addresses = new List<AddressDto>();
         cDto.Addresses.Add(c.ToAddress1Dto());
         cDto.Addresses.Add(c.ToAddress2Dto());
         ...
         return cDto;
          
    
       }
    
      public static AddressDto ToCopmanyAddress1Dto(this Company c){
        return new AddressDto()
         {
          CONTACT_ADDR1 = c.CONTACT_ADDR1,
          CONTACT_ADDR2 = c.CONTACT_ADDR2,
          CONTACT_CITY = c.CONTACT_CITY,
          CONTACT_STATE = c.CONTACT_STATE,
          CONTACT_ZIP = c.CONTACT_ZIP 
         }
      }
    
     public static AddressDto ToCopmanyAddress2Dto(this Company c){
      ...
     }
     
     ... for the other addresses
    }
