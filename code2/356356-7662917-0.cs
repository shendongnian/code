    public class infoContactComparer : IEqualityComparer<infoContact>
	{
		public bool Equals(infoContact x, infoContact y)
		{
			return x.contacts_first_nameField == y.contacts_first_nameField
				&& x.contacts_last_nameField == y.contacts_last_nameField
				&& ...
		}
		public int GetHashCode(infoContact obj)
		{
			return obj.contacts_first_nameField.GetHashCode();
		}
	}
