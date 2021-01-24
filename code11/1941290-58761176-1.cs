var sql = "INSERT INTO wire_transfer_request(request_date, requester_name, authorizer_name," +
		 "authorizer_signature, transfer_date, customer_names," +
		 "customer_reasons, customer_amounts, total_of_customer_amounts)" +
"VALUES (@request_date, @requester_name, @authorizer_name," +
		 "@authorizer_signature, @transfer_date, @customer_names," +
		 "@customer_reasons, @customer_amounts, @total_of_customer_amounts); SELECT SCOPE_IDENTITY()";
var o = new 
{
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
var inserted = conn.ExecuteScalar(sql, o);
`inserted` contains the `request_id` of the newly inserted row. 
# Option 1. A class for the table
`Insert` (which is not the core of this answer) is from the official [Dapper.Contrib](https://github.com/StackExchange/Dapper/tree/master/Dapper.Contrib).
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
