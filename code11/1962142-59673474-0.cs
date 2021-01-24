internal class ProductOrderDetail
{
    public int ProductId { get; set; }
    public int OrderId { get; set; }
}
public IEnumerable<ProductOrderDetail> GetProductOrderDetail(IEnumerable<int> productIds, IEnumerable<int> OrderIds)
{
    var query = (from p in products
                join o in orders on p.productId equals o.product_id_fk
                where o.customerId_fk == this.CustomerId
                where productIds.Contains(p.productId)
                where orderIds.Contains(o.orderId)
                select new ProductOrderDetail()
                {
                    ProductId = p.productId,
                    OrderId = o.orderId
                });
    return query;
}
Usage:
var productIds = { 1, 2, 3 };
var orderIds = { 11154, 13157 };
List<ProductOrderDetail> results = GetProductOrderDetail(productIds, OrderIds).ToList();
This gets you a list of product/order id pairs.
