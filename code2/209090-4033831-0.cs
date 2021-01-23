    private EnumDataType dataType;
    public EnumDataType
    {
       get
       {
           if(datatype == null)
           {
              dataType = EnumDataType.Apple;
           } 
           return dataType;
       }
       set
       {
           dataType = value;
       }
     }
