	public class Button
	{
		public event Action<UIButtonX, int> onClicked;
		public int Id { get; set; }
		
		protected virtual void OnClicked ()
		{
			var e = this.onClicked;
			if (e != null)
			{
				e(this, this.Id);
			}
		}
	}
