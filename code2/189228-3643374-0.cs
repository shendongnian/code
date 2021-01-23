    public partial class Item
	{
		public int Rating
		{
			get
			{
				if (!Thread.CurrentPrincipal.Identity.IsAuthenticated)
					return 0;
				using (var db = new ApplicationDataContext())
				{
					return db.Item
						.Where(r => r.ItemID == this.ItemID
							&& r.UserID == Thread.CurrentPrincipal.Identity.Name)
						.Select(r => r.Rating)
						.SingleOrDefault();
				}
			}
		}
	}
