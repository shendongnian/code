	private class CustomDocumentRenderer : DocumentRenderer
	{
		public CustomDocumentRenderer(Document document) : base(document)
		{}
		protected internal override LayoutArea UpdateCurrentArea(LayoutResult overflowResult)
		{
			currentArea = (RootLayoutArea) base.UpdateCurrentArea(overflowResult);
			if (currentArea.pageNumber == 1)
			{
				currentArea.SetBBox(new Rectangle(14, 390 - 243, 567, 243));
			}
			else
			{
				currentArea.SetBBox(new Rectangle(14, 675 - 661, 567, 661));
			}
			return currentArea;
		}
	}
