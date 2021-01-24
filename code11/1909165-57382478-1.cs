public class IOrderService
{
    string SetOrderNumber();
}
public class OrderService : IOrderService
{
    private readonly Random random = new Random();
    private string loadOrderNr()
    {
       long part1 = rnd.Next(100000, 999999);
       long part2 = rnd.Next(1000, 9999);
       return "CA-" + part1 + "-" + part2;
    } 
    public string SetOrderNumber()
    {
        string OrderNumber = "";
        do
        {
           OrderNumber = loadOrderNr();
        }
        while (!db.CarAnn.Any(x => x.OrderNr == OrderNumber));
    }
}
DB-Stuff
using (Db db = new Db())
{
     CarAnn ann = new CarAnn();                         
     ann.Description = model.Description;
     ann.Title = model.Title;
     ann.OrderNr = IOrderService.SetOrderNumber(); 
     db.CarAnn.Add(ann);
     db.SaveChanges();
}
