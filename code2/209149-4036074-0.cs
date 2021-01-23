    public static class OrderStatusExtensions
    {
        public static bool IsAccepted(this OrderStatuses status)
        {
            return status == OrderStatuses.Valid
                || status == OrderStatuses.Active
                || status == OrderStatuses.Processed
                || status == OrderStatuses.Completed;
        }
    }
    var acceptedOrders = from o in orders
                         where o.Status.IsAccepted()
                         select o;
