		sealed class CompareUsersById : IEqualityComparer<User>
		{
			public bool Equals(User x, User y)
			{
				if(x == null)
					return y == null;
				else if(y == null)
					return false;
				else
					return x.ID == y.ID;
			}
			public int GetHashCode(User obj)
			{
				return obj.ID;
			}
		}
