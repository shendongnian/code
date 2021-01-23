    namespace MyNamespace
    { 
       class Program
       {
           static void Main(string[] args)
           {
               MyClass mc = new MyClass();
           }
       }
    }
    namespace DifferentNamespace
    {
       class MyClass
       {
          internal MyClass()
          {
          }
       }
    }
