    public void RemoveOrder(Order order)
    {
     try
        {
            using (tempPosOrderPaymentDBContext db = new tempPosOrderPaymentDBContext ())
            {
                var orderInDb = db.Orders.First(x=> x.OrderId == order.OrderId);
                db.Orders.Remove(orderInDb);
                db.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            CustomExceptionHandling customExceptionHandling = new CustomExceptionHandling();
            customExceptionHandling.CustomExHandling(ex.ToString());
        }
}
