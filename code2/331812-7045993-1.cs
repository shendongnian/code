    enum MyActions
    {
       Action1,
       Action2,
       Action3
    }
    
    public DoStuff(MyActions theAction, Itemlist theList)
    {
       foreach (SomeItem in theList)
       {
           // do any common stuff
           switch (theAction)
           {
               case Action1:
                  //Action 1 specific stuff
                  break;
               case Action2:
                  //Action 2 specific stuff
                  break;
               case Action3:
                  //Action 3 specific stuff
                  break;
           }
       }
    }
