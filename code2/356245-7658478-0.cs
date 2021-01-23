    protected MyContext Context
    {
        get
        {
            var context = HttpContext.Current.Items["MyContext"];
            if (context == null)
            {
                context = new MyContext();
                HttpContext.Current.Items.Add("MyContext", context);
            }
            return context as MyContext;
        }
    }  
