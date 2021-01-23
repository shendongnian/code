       public class BasePage : System.Web.UI.Page
        {
         public Foo CurrentFoo
                {
                    get
                    {
                        return (Foo)Session["FooSessionObject"];
                    }
                    set
                        {
                        if(Session["FooSessionObject"]==null)
                        { //instantiate a new one
                           Session["FooSessionObject"] = new Foo();
                        }
                        Session["FooSessionObject"] = value;
                    }
                }
    }
