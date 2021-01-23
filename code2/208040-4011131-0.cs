      class A
      {
      }
      class A<T>
      {}
      class Program
      {
        static public void Main(string[] args)
        {
          A a = new A();
          A<int> generic_a = new A<int>();
        }
      }
