    public override void RenderForm(StringBuilder result)
    {
        _form1.RenderForm(result);
        _form2.RenderForm(result);
    }
    ....
    public override void RenderForm(StringBuilder result)
    {
        result.Append("<span class='FormName'>");
        result.Append(this.FormName);
        result.Append("</span>");        
    }
