    void ButtonClick_H1(...)
    {
      ClassName a;          //local variable
      a = new ClassName();  // object belongs to this method
    }
    
    
    private  ClassName anObject;   // class field
    void ButtonClick_H2(...)
    { 
      anObject = new ClassName();  // object belongs to  'this' Form
    }
