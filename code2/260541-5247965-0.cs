    public interface IOrder
    {
        void AttachAsModifiedToOrders(IOrder order, params Expression<Func<IOrder, object[]>>[] modifiedProperties);
    }
    public class Manipulator
    {
        public Manipulator(IOrder order)
        {
            Expression<Func<IOrder, object[]>> exp = o => new object[0];
            order.AttachAsModifiedToOrders(order, exp);
        }
        public void DoStuff() { }
    }
