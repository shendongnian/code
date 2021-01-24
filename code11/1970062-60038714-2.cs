cs
public class xpubaddress
{
	public int final_balance { get; set; }
	public int n_tx { get; set; }
	public int total_received { get; set; }
}
and then deserialize it into `IDictionary<string, xpubaddress>` for example, add access objects using the `xpubaddressONE`, `xpubaddressTWO`, etc., keys
cs
var result = JsonConvert.DeserializeObject<IDictionary<string, xpubaddress>>(json);
var balance = result?["xpubaddressONE"]?.final_balance ?? 0;
