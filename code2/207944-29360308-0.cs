        class samle {
          int x;
          public sample(int value){
            x = value;
          }
        }
        class der : public sample {
          int a;
          int b;
          public der(int value1,int value2):base(50){
            a = value1;
            b = value2;
        }
        class run{
         public static void main(String[] args){
           der obj = new der(10,20);
           Console.WriteLine(obj.x);
           Console.WriteLine(obj.a);
           Console.WriteLine(obj.b);
         }
        }
