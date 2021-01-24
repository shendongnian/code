    public async Task<List<Order>> Execute(OrderQuery query)
    {
        var sql = $@"SELECT
	                    ...
                    FROM vwweb_Orders
                    WHERE @{nameof(query.CustomerId)} <= 0 OR customer_id = @{nameof(query.CustomerId)}
                        AND ISNULL(@{nameof(query.CustomerName)}, '') = '' OR customer_name = @{nameof(query.CustomerName)}";
        return await conn.QueryAsync<Order>(sql, new { query.CustomerId, query.CustomerName});
    }
    public class OrderQuery
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
    public class Order
    {
    }
