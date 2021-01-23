    class Item {
       public int Value { get; set; }
       public string CssClass { get; set; }
       public string Description{ get; set; }
    }
    private const string EMPTY_OPTION = "<option value=''></option>";
    [HttpGet]
    public string Action(int id) 
    {
        // Load a collection with all your option's related data
        IQueryable data = LoadSomethingFromDbOrWherever(id);
        // Build output
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("<select id='foo' name='foo'>");
        sb.AppendFormat(EMPTY_OPTION);
        foreach (Item b in data)
        {
                sb.AppendFormat("<option value='{0}' class='{1}'>{2}</option>",
                                b.Value, b.CssClass, b.Description);
        }
        sb.AppendFormat("</select>");
        return sb.ToString();
    }
