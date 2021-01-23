    public delegate void VoidDelegate();
    
    public static class Utils
    {
      public static void Try(VoidDelegate v) {
        try {
          v();
        }
        catch {}
      }
    }
    
    Utils.Try( () => WidgetMaker.SetAlignment(57) );
    Utils.Try( () => arrayname["Title"] = txtTitle.Text );
    Utils.Try( () => objectname.Season(true, false) );
    Utils.Try( () => (Session["CasseroleTracker"]).Seasoned = true );
