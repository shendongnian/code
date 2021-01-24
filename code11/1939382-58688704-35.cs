using System.Collections.Generic;
public class ReasonMetaData
{
  static public Dictionary<Reason, ReasonMetaData> All { get; private set; }
  static ReasonMetaData()
  {
    All = new Dictionary<Reason, ReasonMetaData>();
    All.Add(
      Reason.NotEnoughStock,
      new ReasonMetaData(Responsability.Company, true, "There is not enough stock"));
    All.Add(
      Reason.ProductNotAvailabe,
      new ReasonMetaData(Responsability.Company, false, "Product is not available"));
    All.Add(
      Reason.PaymentNotDone,
      new ReasonMetaData(Responsability.Client, false, "Payment is not done"));
    All.Add(
      Reason.BlackListedClient,
      new ReasonMetaData(Responsability.Client, false, "Client is black listed"));
    All.Add(
      Reason.NotEnoughTime,
      new ReasonMetaData(Responsability.Company, true, "There is not enough time"));
  }
  static public ReasonMetaData Get(Reason reason)
  {
    if ( All.ContainsKey(reason) )
      return All[reason];
    else
      return null;
  }
  public Responsability Responsability { get; private set; }
  public bool Valid { get; private set; }
  public string Text { get; private set; }
  public override string ToString()
  {
    return $"Responsability = {Enum.GetName(typeof(Responsability), Responsability)}, " +
           $"Valid = {( Valid ? "yes" : "no" )}" +
           $"Text = {Text}";
  }
  private ReasonMetaData()
  {
  }
  private ReasonMetaData(Responsability responsability, bool valid, string text)
  {
    Responsability = responsability;
    Valid = valid;
    Text = text;
  }
}
You can also create an extension method as suggested by @RawitasKrungkaew:
>ReasonMetadataHelper.cs
    static public class ReasonMetadataHelper
    {
      static public ReasonMetaData GetMetaData(this Reason reason)
      {
        return ReasonMetaData.Get(reason);
      }
    }
<h3>Usage and test</h3>
    static void Test()
    {
      Console.WriteLine("Metadata of Reason.NotEnoughStock is:");
      Console.WriteLine(Reason.NotEnoughStock.GetMetaData());
      Console.WriteLine("");
      Console.WriteLine("Metadata of Reason.ProductNotAvailabe is:");
      Console.WriteLine(ReasonMetaData.Get(Reason.ProductNotAvailabe));
      Console.WriteLine("");
      Console.WriteLine("All metadata of Reason enum are:");
      foreach ( var item in ReasonMetaData.All )
        Console.WriteLine($"  {item.Key}: {item.Value}");
    }
<h3>Output</h3>
    Metadata of Reason.NotEnoughStock is:
    Responsability = Company, Valid = yes, Text = There is not enough stock
    Metadata of Reason.ProductNotAvailabe is:
    Responsability = Company, Valid = no, Text = Product is not available
    All metadata of Reason enum are:
      NotEnoughStock: Responsability = Company, Valid = yes, Text = There is not enough stock
      ProductNotAvailabe: Responsability = Company, Valid = no, Text = Product is not available
      PaymentNotDone: Responsability = Client, Valid = no, Text = Payment is not done
      BlackListedClient: Responsability = Client, Valid = no, Text = Client is black listed
      NotEnoughTime: Responsability = Company, Valid = yes, Text = There is not enough time
<h3>Improvement</h3>
You can mix this solution with attributes to create the list automatically by parsing attributes of enum items:
So having:
>ReasonAttributes.cs
    public class ReasonResponsabilityAttribute : Attribute
    {
      public Responsability Responsability { get; private set; }
      public ReasonResponsabilityAttribute(Responsability responsability)
      {
        Responsability = responsability;
      }
    }
    public class ReasonValidAttribute : Attribute
    {
      public bool Valid { get; private set; }
      public ReasonValidAttribute(bool valid)
      {
        Valid = valid;
      }
    }
    public class ReasonTextAttribute : Attribute
    {
      public string Text { get; private set; }
      public ReasonTextAttribute(string text)
      {
        Text = text;
      }
    }
>Reason.cs is now:
    public enum Reason
    {
      [ReasonResponsability(Responsability.Company)]
      [ReasonValid(true)]
      [ReasonText("There is not enough stock")]
      NotEnoughStock,
      // ...
      ProductNotAvailabe,
      // ...
      PaymentNotDone,
      // ...
      BlackListedClient,
      // ...
      NotEnoughTime
    }
>ReasonMetadata.cs static constructor is now:
    using System.Reflection;
    static ReasonMetaData()
    {
      All = new Dictionary<Reason, ReasonMetaData>();
      var list = Enum.GetValues(typeof(Reason));
      foreach ( Reason reason in list )
      {
        var metadata = new ReasonMetaData();
        var memberinfo = reason.GetType().GetMember(Enum.GetName(typeof(Reason), reason));
        if ( memberinfo.Length == 1 )
        {
          var attributes = memberinfo[0].GetCustomAttributes();
          foreach ( Attribute attribute in attributes )
            if ( attribute is ReasonResponsabilityAttribute )
              metadata.Responsability = ( (ReasonResponsabilityAttribute)attribute ).Responsability;
            else
            if ( attribute is ReasonValidAttribute )
              metadata.Valid = ( (ReasonValidAttribute)attribute ).Valid;
            else
            if ( attribute is ReasonTextAttribute )
              metadata.Text = ( (ReasonTextAttribute)attribute ).Text;
        }
        All.Add(reason, metadata);
      }
    }
<h3>Using only one attribute</h3>
>ReasonMetadataAttribute.cs
    public class ReasonMetadataAttribute : Attribute
    {
      public Responsability Responsability { get; private set; }
      public bool Valid { get; private set; }
      public string Text { get; private set; }
      public ReasonMetadataAttribute(Responsability responsability, bool valid, string text)
      {
        Responsability = responsability;
        Valid = valid;
        Text = text;
      }
    }
>ReasonMetadata.cs static constructor is now:
    static ReasonMetaData()
    {
      All = new Dictionary<Reason, ReasonMetaData>();
      var list = Enum.GetValues(typeof(Reason));
      foreach ( Reason reason in list )
      {
        var metadata = new ReasonMetaData();
        var memberinfo = reason.GetType().GetMember(Enum.GetName(typeof(Reason), reason));
        if ( memberinfo.Length == 1 )
        {
          var attributes = memberinfo[0].GetCustomAttributes();
          foreach ( Attribute attribute in attributes )
            if ( attribute is ReasonMetadataAttribute )
            {
              var metadataAttribute = (ReasonMetadataAttribute)attribute;
              metadata.Responsability = metadataAttribute.Responsability;
              metadata.Valid = metadataAttribute.Valid;
              metadata.Text = metadataAttribute.Text;
            }
        }
        All.Add(reason, metadata);
      }
    }
Usage:
    public enum Reason
    {
      [ReasonMetadata(Responsability.Company, true, "There is not enough stock")]
      NotEnoughStock,
      // ...
      ProductNotAvailabe,
      // ...
      PaymentNotDone,
      // ...
      BlackListedClient,
      // ...
      NotEnoughTime
    }
