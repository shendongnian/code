    protected override void Render(HtmlTextWriter writer)
    {
        StringWriter strWriter = new StringWriter();
        base.Render(new HtmlTextWriter(strWriter));
        writer.Write(strWriter.ToString().
            Replace("id: \"" + DropDownList1.ClientID + "\",",
                    "id: \"" + DropDownList1.ClientID + "\",editable:true,hideTrigger:true,")
        );
    }
