using System.Collections.Generic;
public class ReasonMetaData
{
  static public Dictionary<Reason, ReasonMetaData> All { get; private set; }
  static ReasonMetaData()
  {
    All = new Dictionary<Reason, ReasonMetaData>();
    All.Add(
      Reason.NotEnoughStock,
      new ReasonMetaData(Responsability.Company, "There is not enough stock", true));
    All.Add(
      Reason.ProductNotAvailabe,
      new ReasonMetaData(Responsability.Company, "Product is not available", false));
    All.Add(
      Reason.PaymentNotDone,
      new ReasonMetaData(Responsability.Client, "Payment is not done", false));
    All.Add(
      Reason.BlackListedClient,
      new ReasonMetaData(Responsability.Client, "Client is black listed", false));
    All.Add(
      Reason.NotEnoughTime,
      new ReasonMetaData(Responsability.Company, "There is not enough time", true));
  }
  static public ReasonMetaData Get(Reason index)
  {
    return All[index];
  }
  public Responsability Responsability { get; }
  public string Text { get; }
  public bool Valid { get; }
  public override string ToString()
  {
    return $"Responsability = {Enum.GetName(typeof(Responsability), Responsability)}, " +
           $"Text = {Text}, " +
           $"Valid = {( Valid ? "yes" : "no" )}";
  }
  private ReasonMetaData(Responsability responsability, string text, bool valid)
  {
    Responsability = responsability;
    Text = text;
    Valid = valid;
  }
}
<h3>Usage and test</h3>
    static void Test()
    {
      Console.WriteLine("Metadata of Reason.NotEnoughStock is:");
      Console.WriteLine(ReasonMetaData.Get(Reason.NotEnoughStock));
      Console.WriteLine("");
      Console.WriteLine("All metadata of Reason enum are:");
      foreach ( var item in ReasonMetaData.Items )
        Console.WriteLine($"  {item.Key}: {item.Value}");
    }
<h3>Output</h3>
    Metadata of Reason.NotEnoughStock is:
    Responsability = Company, Text = There is not enough stock, Valid = yes
    All metadata of Reason enum are:
      NotEnoughStock: Responsability = Company, Text = There is not enough stock, Valid = yes
      ProductNotAvailabe: Responsability = Company, Text = Product is not available, Valid = no
      PaymentNotDone: Responsability = Client, Text = Payment is not done, Valid = no
      BlackListedClient: Responsability = Client, Text = Client is black listed, Valid = no
      NotEnoughTime: Responsability = Company, Text = There is not enough time, Valid = yes
