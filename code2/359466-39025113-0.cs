	public class OrderRelatedIds
	{
		public int OrderGroupId { get; set; }
		public int OrderTypeId { get; set; }
		public int OrderSubTypeId { get; set; }
		public int OrderRequirementId { get; set; }
		public OrderRelatedIds()
		{
		}
		public OrderRelatedIds(int orderGroupId)
			: this()
		{
			OrderGroupId = orderGroupId;
		}
		public OrderRelatedIds(int orderGroupId, int orderTypeId)
			: this(orderGroupId)
		{
			OrderTypeId = orderTypeId;
		}
		public OrderRelatedIds(int orderGroupId, int orderTypeId, int orderSubTypeId)
			: this(orderGroupId, orderTypeId)
		{
			OrderSubTypeId = orderSubTypeId;
		}
		public OrderRelatedIds(int orderGroupId, int orderTypeId, int orderSubTypeId, int orderRequirementId)
			: this(orderGroupId, orderTypeId, orderSubTypeId)
		{
			OrderRequirementId = orderRequirementId;
		}
	}
