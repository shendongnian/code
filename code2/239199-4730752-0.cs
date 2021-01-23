    protected override void OnInit(EventArgs e)
    {
      base.OnInit(e);
      ScriptManager.GetCurrent(this)
        .ResolveScriptReference += new EventHandler<ScriptReferenceEventArgs>(ResolveScriptReferenceHandler);
    }
    List<string> ScriptRefs = new List<string>();
    private void ResolveScriptReferenceHandler(object sender, ScriptReferenceEventArgs e)
    {
      ScriptRefs.Add("<asp:ScriptReference Name=\"" + e.Script.Name + "\" Assembly=\"" + e.Script.Assembly + "\" />");
    }
    protected override void Render(HtmlTextWriter output)
    {
      base.Render(output);
      string debug = string.Join("\r\n", ScriptRefs.Distinct());
    }
