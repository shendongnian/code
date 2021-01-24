void Main()
{
	Reason.NotEnoughStock.GetAttributeOfType<DescriptionAttribute>().Description;
	Reason.ProductNotAvailabe.GetAttributeOfType<ResponsabilityAttribute>().Responsability;
}
public enum Reason
{
    [Description("There is not enough stock")]
	[Valid(true)]
	[Responsability("company")]
	NotEnoughStock, 
	[Description("Produc is not available")]
	[Valid(false)]
	[Responsability("company")]
	ProductNotAvailabe,
	[Description("Payment is not done")]
	[Valid(false)]
	[Responsability("client")]
	PaymentNotDone, 
	[Description("Client is black listed")]
	[Valid(false)]
	[Responsability("client")]
	BlackListedClient, 
	[Description("There is not enough time")]
	[Valid(true)]
	[Responsability("company")]
	NotEnoughTime 
}
public static class EnumHelper
{
	/// <summary>
	/// Gets an attribute on an enum field value
	/// </summary>
	/// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
	/// <param name="enumVal">The enum value</param>
	/// <returns>The attribute of type T that exists on the enum value</returns>
	/// <example>string desc = myEnumVariable.GetAttributeOfType<DescriptionAttribute>().Description;</example>
	public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
	{
		var type = enumVal.GetType();
		var memInfo = type.GetMember(enumVal.ToString());
		var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
		return (attributes.Length > 0) ? (T)attributes[0] : null;
	}
}
public class ValidAttribute : Attribute
{
	public bool Valid;
	public ValidAttribute(bool valid) { Valid = valid; }
}
public class ResponsabilityAttribute : Attribute
{
	public string Responsability;
	public ResponsabilityAttribute(string responsability) { Responsability = responsability; }
}
