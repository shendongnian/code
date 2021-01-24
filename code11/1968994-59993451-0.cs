    abstract class LoggableEventBase
    {
        public string ActionName { get; }
        public string ActionOrigin { get; }
        public LoggableEventBase(string actionName, string actionOrigin)
        {
            ActionName = actionName;
            ActionOrigin = actionOrigin;
        }
        public virtual string Serialize()
        {
            return string.Format("{0} {1}", ActionName, ActionOrigin);
        }
    }
    class CreateOrderEvent : LoggableEventBase
    {
        protected readonly List<Item> _items;
        protected readonly int _orderId;
        public CreateOrderEvent(string origin, int orderID, List<Item> items) : base("CreateOrder", origin)
        {
            _orderId = orderID;
            _items = items;
        }
        public override string Serialize()
        {
            return base.Serialize() + string.Format(" {0} {1}", _orderId, string.Join(",", _items.Select(item => item.SKU)));
        }
    }
