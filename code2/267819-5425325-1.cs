	public class ClickableTableCell : TableCell, IPostBackEventHandler
	{
		public event EventHandler Click;
		public override void RenderBeginTag(HtmlTextWriter writer)
		{
			Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(this, null));
			base.RenderBeginTag(writer);
		}
		public void RaisePostBackEvent(string eventArgument)
		{
			OnClick(new EventArgs());
		}
		protected void OnClick(EventArgs e)
		{
			if (Click != null)
				Click(this, e);
		}
	}
