    <asp:CheckBoxList ID="CheckBoxList1" runat="server"
    DataSourceID="dataSourceID"
    DataTextField="dataTextField"
    DataValueField="dataTextValue"
    OnDataBound="CheckBoxList1_DataBound">
    </asp:CheckBoxList>
    protected void CheckBoxList1_DataBound(object sender, EventArgs e)
    {
        var checkBox = sender as CheckBoxList;
        if(checkBox != null)
        {
            foreach (ListItem listItem in checkBox.Items)
            {
                listItem.Text = string.Format("{0}<img src='{1}' />", listItem.Text, GetImageFor(listItem.Text));
            }
        }
    }
    private string GetImageFor(string text)
    {
        // return image url for check box based on text.
      
        if(text.Equals("Banana")) return "banana.gif";
        ...
        ...
    }
