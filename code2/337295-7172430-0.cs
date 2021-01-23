    public string GetName(GridViewColumn column)
    {
        var findMatch = from field in this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                        let fieldValue = field.GetValue(this)
                        where fieldValue == column
                        select field.Name;
        return findMatch.FirstOrDefault();
    }
