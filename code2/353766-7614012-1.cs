	[AttributeUsage(AttributeTargets.Property)]
	public class PropertyGroupAttribute : Attribute {
		public PropertyGroupAttribute(int groupId) {
			this.GroupId = groupId;
		}
		public int GroupId { get; set; }
	}
