    public static class CommonEventHandlers
    {
        public static void Page_Loaded(object sender, EventArgs e)
        {
            //Do any standard logic
            //If you need a reference to the page that raised the event, 
            //   you can get it from the 'sender' parameter.
            Page page = (Page)sender;
            //Do something with 'page'
        }
    }
