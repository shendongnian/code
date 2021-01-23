    class baseCls
    {
      private string _name;
      public DTO_base ToDTO()
      {
        DTO_base result = createDTO();
        result.Name = _name;
        setAdditionalData(result);
        return result;
      }
      protected abstract DTO_base createDTO();
      protected abstract void setAdditionalData(DTO_base dto);
    }
    class inherited : baseCls
    {
      private string _description;
      protected override DTO_base createDTO() {
        return new DTO_inerited();
      }
      protected override void setAdditionalData(DTO_base dto) {
         inherited i = (DTO_inherited)dto;
         i.Description = _Description;
      }
    }
