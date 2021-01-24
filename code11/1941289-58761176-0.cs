[Table("wire_transfer_request")]
public class WireTransferRequest2
{
	public int request_id { get; set; }
	public DateTime request_date { get; set; }
	public string requester_name { get; set; }
	public string authorizer_name { get; set; }
	public string authorizer_signature { get; set; }
	public DateTime transfer_date { get; set; }
	public string customer_names { get; set; }
	public string customer_reasons { get; set; }
	public string customer_amounts { get; set; }
	public decimal total_of_customer_amounts { get; set; }
}
using Dapper.Contrib.Extensions;
(...)
var o = new WireTransferRequest2
{
	request_id = 1,
	request_date = DateTime.UtcNow,
	requester_name = "X",
	authorizer_name = "Y",
	authorizer_signature = "Sig",
	transfer_date = DateTime.UtcNow,
	customer_names = "Z", 
	customer_reasons = "A",
	customer_amounts = "B",
	total_of_customer_amounts = 10m,
};
conn.Insert(o);
# Option 2. Use `ColumnAttribute`
Details at https://stackoverflow.com/questions/8902674/manually-map-column-names-with-class-properties.
