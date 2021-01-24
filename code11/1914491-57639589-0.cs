    <asp:Button ID="btnAddContainer" OnCommand="ContainerforAccession" 
    protected void ContainerforAccession(object sender, CommandEventArgs e)
    {
        string AccessionID = e.CommandArgument.ToString();
    }
