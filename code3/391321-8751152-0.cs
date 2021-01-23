    public class AbstractInheritance
        {
            public abstract class Order
            {
                internal int Internal { get; set; }
                protected int Protected { get; set; }
                public int Public { get; set; }
                public int ProtectedVal { get { return Protected; } }
            }
            public class ConcreteOrder : Order
            {
                public int Concrete { get; set; }
            }
        }
        // http://stackoverflow.com/q/8593871
        public void TestAbstractInheritance() 
        {
            var order = connection.Query<AbstractInheritance.ConcreteOrder>("select 1 Internal,2 Protected,3 [Public],4 Concrete").First();
            order.Internal.IsEqualTo(1);
            order.ProtectedVal.IsEqualTo(2);
            order.Public.IsEqualTo(3);
            order.Concrete.IsEqualTo(4);
            
        }
