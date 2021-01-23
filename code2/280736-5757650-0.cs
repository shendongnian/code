    List<DocumentType> documentTypes = new List<DocumentType>();
    documentTypes.Add(new DocumentType(){ ID=1, Name="Bob"});
    documentTypes.Add(new DocumentType() { ID = 2, Name = "Tom" });
    documentTypes.Add(new DocumentType() { ID = 3, Name = "Chick" });
    Repeater docList = new Repeater();
    docList.DataSource = documentTypes;
    docList.DataBind();
    foreach (RepeaterItem repeatItem in docList.Items)
    {
        int index = repeatItem.ItemIndex;
        DocumentType docType = ((IList<DocumentType>)docList.DataSource)[index];
        // if condition to add HeaderTemplate Dynamically only Once
        if (index == 0)
        {
            HtmlGenericControl hTag = new HtmlGenericControl("h4");
            hTag.InnerHtml = "Header";
            repeatItem.Controls.Add(hTag);
        }
        // Add ItemTemplate DataItems Dynamically
        RepeaterItem repeaterItem = new RepeaterItem(repeatItem.ItemIndex, ListItemType.Item);
        Label lbl = new Label();
        // This part is completely broken!
        lbl.Text = string.Format("Content: {0} {1} <br />", docType.ID, repeaterItem.NamingContainer);
        repeatItem.Controls.Add(lbl);
        // Add SeparatorTemplate Dynamically
        LiteralControl ltrlHR = new LiteralControl();
        ltrlHR.Text = "<hr />";
        repeatItem.Controls.Add(ltrlHR);
    }
    StringBuilder sb = new StringBuilder();
    docList.RenderControl(new HtmlTextWriter(new StringWriter(sb)));
    Text = sb.ToString();
