    public static mySession Current
    {
      get
      {
        mySession session =
          (mySession)HttpContext.Current.Session["__MySession__"];
        if (session == null)
        {
          session = new mySession();
          HttpContext.Current.Session["__MySession__"] = session;
          session._cart = new ShoppingCart(); //initialize your shoppoing car after adding variable to session !
        }
        return session;
      }
    }
    public ShoppingCart _cart;// = new ShoppingCart(); remove initialization
