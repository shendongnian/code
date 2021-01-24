 c#
public class Products
{
    public string SKU {get;set;}
    public string Title {get;set;}
    public string ImageLink {get;set;}
}
and try again; you only need to pass the single object - you don't need a list here. You can *combine* this with the `CommandType.StoredProcedure` approach if you choose (as noted by MarcinJ) - but be careful that this exchanges *positional* parameter passing (in the original question) to *named* parameter passing - so be sure to check that this doesn't change the meaning.
