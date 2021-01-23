    public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
    {
        var result = 
            from e in Enum.GetValues(typeof(TEnum)).Cast<TEnum>()
            select new 
            { 
                Id = (int)Enum.Parse(typeof(TEnum), e.ToString()), 
                Name = e.ToString() 
            };
        return new SelectList(result, "Id", "Name", enumObj);
    }
