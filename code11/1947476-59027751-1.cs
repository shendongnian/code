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
  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/enum
