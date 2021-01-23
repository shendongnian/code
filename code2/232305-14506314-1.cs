    struct Test
    {
       public int value;
       public void setInt(int val)
       {
          value = val;
       }
    }
    
    static class Program
    {
       public static readonly Test t = new Test();
    
       static void Main()
       {
          Console.WriteLine(t.value); // Outputs "0"
          t.setInt(10);
          //t.value = 10;  //Illegal, will not let you assign field of a static struct
          Console.WriteLine(t.value); // Still outputs "0"
       }
    }
