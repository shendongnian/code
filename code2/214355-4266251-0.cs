    public class CustomControls
    {
        private readonly HtmlHelper _helper;
        public CustomControls(HtmlHelper helper)
        {
           _helper = helper;
        }
        public static string DropDown()
        {
           //Custom code here
        }
     }
     public CustomControls CustomControls(this HtmlHelper helper)
     {
        return new CustomControls(helper);
     }
