     abstract class Super
     {
         protected readonly int Field;
         
         protected Super(int field)
         {
              this.Field = field;
         }
     }
    class Sub : Super {
       public Sub():base(5)
       {
       }
   }
