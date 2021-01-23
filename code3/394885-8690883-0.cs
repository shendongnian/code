      protected override void OnInit(EventArgs e)
      {
        base.OnInit(e);
        this.Page.ClientScript.RegisterClientScriptInclude(
           this.GetType(), "libscript", 
           Page.ClientScript.GetWebResourceUrl(this.GetType(), 
           "Library.Resources.Scripts.libscript.js"));
      }
