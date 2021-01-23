    public class User
        {
    
            private string ffName;
            private string llName;
            private int id = 0;
            private Order order = null;
    
            //Constructor
            public User(string firstName, string lastName)
            {
                fName = firstName;
                lName = lastName;
            }
    ...
    }
    public class Order
    {
     List<OrderLine> orderLines = null;
    }
    
    public class OrderLine
    {
    }
