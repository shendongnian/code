using System.ComponentModel.DataAnnotations.Schema;
...
public class ReferralGridRowViewModel
{
	...
	[NotMapped]
	public int YearToDate {
    get {
      return (January + February + March + April + May + June + July + August + September + October + November + December);
    }
  }
}
It indicates to the EF to ignore the property on the db side. See the docs:  
https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.schema.notmappedattribute?view=netframework-4.8
