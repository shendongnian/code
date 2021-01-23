	public class OrderMap : ClassMap<Order>
	{
		public OrderMap()
		{
			Id(c => c.Id, "order_id").GeneratedBy.Native();
			Table("order");
			Map(c => c.GroupId, "group_id");
			Map(c => c.Status, "status");
			Map(c => c.LocationNumber, "location");
			SqlInsert("insert into order (group_id, status, location) values (?, ?, ?)").Check.None();
			SqlUpdate("update order set group_id = ?, status = ?, location = ? where order_id = ?")).Check.None();
			SqlDelete("delete order where order_id = ?").Check.None();
		}
	}
