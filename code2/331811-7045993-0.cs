    enum MyActions
    {
       Action1,
       Action2,
       Action3
    }
    
    private DoStuff(MyActions theAction)
    {
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
