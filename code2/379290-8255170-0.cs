    List listData {get; set;}
    String Data
    {
        set
        {
            listData.AddRange(value.Split(','));
        }
    }
