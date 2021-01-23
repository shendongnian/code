    protected override void OnInit(EventArgs e)
    {
        DataBinding += BindData;
    }
    public void BindData(object sender, EventArgs e)
    {
        MyLink pl = (MyLink) sender;
        IDataItemContainer container = (IDataItemContainer) pl.NamingContainer;
        foreach (Action action in _actions)
        {
            action.Url = ReplaceTokens(action.Url, container);
            action.Text = ReplaceTokens(action.Text, container);
        }
    }
    private static string ReplaceTokens(string text, IDataItemContainer container)
    {
        Regex re = new Regex("##.*?##", RegexOptions.Compiled | RegexOptions.Singleline);
        StringBuilder sb = new StringBuilder(text);
        foreach (Match m in re.Matches(text))
        {
            string tokenValue = DataBinder.GetPropertyValue(container.DataItem, m.Value.Substring(2, m.Value.Length - 4), "{0}");
            sb.Replace(m.Value, tokenValue);
        }
        return sb.ToString();
    }
