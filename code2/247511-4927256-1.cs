    private List<Shopping> ShoppingList
    {
       get { 
              var shopping = Session["Shopping"] as List<Shopping>;
              if (shopping == null)
              {
                  shopping = new List<Shopping>();
                  Session["Shopping"] = shopping;
              }
              return shopping;
           }
       set { Session["Shopping"] = value; }
    }
