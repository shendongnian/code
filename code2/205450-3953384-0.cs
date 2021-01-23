    class Main {
        static void somefunction(System.String str)
        {
            System.Console.WriteLine("In String overload");
        }
        static void somefunction(System.Object obj)
        {
            System.Console.WriteLine("In Object overload");
        }
        static void somegenericfunction<T>(T object)
        {
            somefunction(object);
        }
        static void dynamicfunction<T>(dynamic T object)
        {
            somefunction(object);
        }
        static void main(System.String[] args)
        {
            somegenericfunction("A string"); // Calls Object overload, even though it's a String.
            dynamicfunction("A string"); // Calls String overload
        }
    }
