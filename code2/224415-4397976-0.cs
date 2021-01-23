	public sealed class CustomRenderer : ToolStripProfessionalRenderer
	{
		protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
		{
			if(e.Item.IsOnDropDown)
			{
				e.TextFormat |= TextFormatFlags.HorizontalCenter;
			}
			base.OnRenderItemText(e);
		}
	}
