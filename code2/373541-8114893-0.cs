    public class SynchronizedTableLayoutPanel : TableLayoutPanel
    	{
		/// <summary>
		/// Specifies a key used to group <see cref="SynchronizedTableLayoutPanel"/>s together.
		/// </summary>
		public String SynchronizationKey
			{
			get { return _SynchronizationKey; }
			set
				{
				if (!String.IsNullOrEmpty(_SynchronizationKey))
					RemoveSyncTarget(this);
				_SynchronizationKey = value;
				if (!String.IsNullOrEmpty(value))
					AddSyncTarget(this);
				}
			} private String _SynchronizationKey;
		#region OnLayout(), Recalculate()
		
		protected override void OnLayout(LayoutEventArgs levent)
			{
			if (ColumnCount > 0 && !String.IsNullOrEmpty(SynchronizationKey))
				{
				Recalculate();
				ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, GetMaxWidth(SynchronizationKey));
				}
			base.OnLayout(levent);
			}
		public void Recalculate()
			{
			var LargestWidth = Enumerable.Range(0, RowCount)
				.Select(i => GetControlFromPosition(0, i))
				.Where(c => c != null)
				.Select(c => (Int32?)((c.AutoSize ? c.GetPreferredSize(new Size(Width, 0)).Width : c.Width)+ c.Margin.Horizontal))
				.Max();
			SetMaxWidth(this, LargestWidth.GetValueOrDefault(0));
			}
		
		#endregion
		#region (Static) Data, cctor, AddSyncTarget(), RemoveSyncTarget(), SetMaxWidth(), GetMaxWidth()
		
		private static readonly Dictionary<SynchronizedTableLayoutPanel, Int32> Data;
		
		static SynchronizedTableLayoutPanel()
			{
			Data = new Dictionary<SynchronizedTableLayoutPanel, Int32>();
			}
		private static void AddSyncTarget(SynchronizedTableLayoutPanel table)
			{
			Data.Add(table, 0);
			}
		private static void RemoveSyncTarget(SynchronizedTableLayoutPanel table)
			{
			Data.Remove(table);
			}
		private static void SetMaxWidth(SynchronizedTableLayoutPanel table, Int32 width)
			{
			Data[table] = width;
			foreach (var pair in Data.ToArray())
				if (pair.Key.SynchronizationKey == table.SynchronizationKey && pair.Value != width)
					pair.Key.PerformLayout();
			}
		private static Int32 GetMaxWidth(String key)
			{
			var MaxWidth = Data
				.Where(p => p.Key.SynchronizationKey == key)
				.Max(p => (Int32?) p.Value);
			return MaxWidth.GetValueOrDefault(0);
			}
		#endregion
		}
