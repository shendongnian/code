    using Scot;
    //..
    public myclass:Document
    {     
        protected override OnConnect()     
        {        
            Elements["mybutton"].OnClick+=new JsInputEventHandler(click); 
            //your initialization        //....     
        }     
        private void click(object sender, JsInputEventArgs e)     
        {        
            Window.Alert("Click()");     
        } 
    }
