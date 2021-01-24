    public static LeadDto ToLeadDto(this Lead lead)
    {
       return new LeadDto(){
          this.Id = lead.Id;
          // Etc..
       }
    }
