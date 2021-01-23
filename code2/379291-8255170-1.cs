    List listData {get; set;}
    String Data
    {
        get
        {
           return String.Empty;
        }
        set
        {
            listData.AddRange(value.Split(','));
        }
    }
