    public class TestControl : UserControl
    {
        public TestControl() { }
        public TestControl(string message)
        {
            SayHello = message;
        }
        public string SayHello { get; set; }
        
        public override void RenderControl(HtmlTextWriter writer)
        {
            base.RenderControl(writer);
            writer.Write(SayHello);
        }
    }
