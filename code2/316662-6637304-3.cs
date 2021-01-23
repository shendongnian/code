    class ObjBB
    {
       public void UseBB() 
       {
           var bb = ObjAA.ReturnA<B>();
           // bb is a B, and the properties it inherits from A are filled
       }
    }
