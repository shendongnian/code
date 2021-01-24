    protected override void OnPreInit(EventArgs e)
    {
         base.OnPreInit(e);
            if (
                    HttpContext.Current.Session.IsNewSession ||
                    HttpContext.Current.Session["LoginUserName"] == null
                )
                
            {
                   ......
            }
            else
                .....
    }
}     
~~~~
