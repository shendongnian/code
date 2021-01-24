 c#
public class xpubaddress
{
    public int final_balance { get; set; }
    public int n_tx { get; set; }
    public int total_received { get; set; }
}
This should then give you a dictionary with 3 *keys* that you can inspect with `foreach`, `TryGetValue`, etc.
---
Alternatively, stick with your root type, but share the inner type:
 c#
public class xpubaddress
{
    public int final_balance { get; set; }
    public int n_tx { get; set; }
    public int total_received { get; set; }
}
public class RootObject
{
    public xpubaddress xpubaddressONE{ get; set; }
    public xpubaddress xpubaddressTWO{ get; set; }
    public xpubaddress xpubaddressTHREE { get; set; }
}
You may also find it easier to leave the property names as idiomatic .NET names, and use `[JsonProperty]` or `[DataMember]` to rename them, i.e.
 c#
[JsonProperty("final_balance")]
public int FinalBalance { get; set; }
