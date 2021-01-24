	private class MyDropSink : SimpleDropSink
	{
		private ObjectListView _olv;
		
		public MyDropSink(ObjectListView olv)
		{
			_olv = olv;
		}
		public override void DrawFeedback(Graphics g, Rectangle bounds)
		{
			if(DropTargetLocation != DropTargetLocation.None)
			{
				Point mLoc = _olv.PointToClient(Cursor.Position);
				var hitt = _olv.HitTest(mLoc);
				if (hitt.Item == null) return;
				int idx = hitt.Item.Index;
				Rectangle rect = _olv.GetItemRect(idx);
				Pen MyPen = new Pen(Color.OrangeRed, 3);
				g.DrawLine(MyPen, rect.Left, rect.Top, rect.Right, rect.Top);
			}
		}
	}
