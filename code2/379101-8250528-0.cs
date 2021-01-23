    List<BaseObject> objects; 
 
    class BaseObject 
    { 
      public void DoStuff(); 
    } 
 
    interface IX 
    { 
      public void DoX(); 
    } 
 
    interface IY 
    { 
      public void DoY(); 
    } 
 
    interface IZ 
    { 
      public void DoZ(); 
    } 
    class X : BaseObject, IX { }
    class Y : BaseOjbect, IY { }
    class Z : BaseObject, IZ {  }
    class XY : BaseObject, IX, IY { }
