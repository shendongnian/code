    public enum PayMethod
    {
        iDeal,
        creditcard,
        PayPal
    }
    public enum OrderStatus
    {
        NotPaid,
        InTheMaking,
        Shipped,
        Delivered,
        Confirmed
    }
public interface IOrderData
{
    OrderStatus Status { get; set; } 
    PayMethod Paymethod { get; set; }
}
public class Order : IOrder, IOrderData
{
public OrderStatus Status { get; set; }
public PayMethod Paymethod { get; set; }
