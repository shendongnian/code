    class A : _base { 
         void Foo() {
             x = 10; //or base.x = 10;
             SetX(10); //or base.SetX(10);
             Console.WriteLine(GetX()); //or base.GetX()
         }
    }
