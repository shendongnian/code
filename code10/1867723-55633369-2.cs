	lvPlaylist.IsSimpleDragSource = true;
	lvPlaylist.DropSink = new MyDropSink();
		
	private class MyDropSink : SimpleDropSink
	{
		public override void DrawFeedback(Graphics g, Rectangle bounds)
		{
			if(DropTargetLocation != DropTargetLocation.None)
				g.DrawString("Heyyy stuffs happening",new Font(FontFamily.GenericMonospace, 10),new SolidBrush(Color.Magenta),bounds.X,bounds.Y );
		}
	}
