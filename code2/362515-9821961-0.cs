		/// <summary>
		/// Enable or Disable all buttons in all groups of the RibbonTab to match toggleButtonActive
		/// toggleButtonActive remains enabled
		/// </summary>
		/// <param name="enabled"></param>
		private void SetUILockState(bool enabled)
		{
			foreach (RibbonGroup group in myRibbonTab.Groups)
			{
				if (group.Items != null)
				{
					foreach (RibbonControl c in group.Items)
					{
						if (c.Name != "toggleButtonActive")
						{
							c.Enabled = enabled;
						}
					}
				}
			}
			// TODO handle right click menus as well
		}
