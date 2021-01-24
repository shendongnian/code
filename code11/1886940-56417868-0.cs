    public class ForeignWindowPasteHelper
    {
    private readonly GlobalEventProvider eventProvider = new GlobalEventProvider();
      public ForeignWindowPasteHelper()
      {
        this.eventProvider.MouseClick += this.GlobalMouseDown;
      }
      private void GlobalMouseDown(object sender, MouseEventArgs e)
      {
        SendKeys.Send("^{v}");
      }
    }
