    namespace Business {
        class Customer {}
        class Order {}
        class OrderLine {}
    }
    var myObject = new Customer();
    Console.WriteLine(myObject.GetType().Namespace); // writes "Business"
