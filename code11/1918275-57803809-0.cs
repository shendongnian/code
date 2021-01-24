    private void CreateDragBitmap(IDataObject data)
		{
			if (!DisplayDraggingNodes) //removed UseColumns as OR condition here
				return;
			TreeNodeAdv[] nodes = data.GetData(typeof(TreeNodeAdv[])) as TreeNodeAdv[];
			if (nodes != null && nodes.Length > 0)
			{
				Rectangle rect = DisplayRectangle;
				Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
				using (Graphics gr = Graphics.FromImage(bitmap))
				{
					gr.Clear(BackColor);
					DrawContext context = new DrawContext();
					context.Graphics = gr;
					context.Font = Font;
					context.Enabled = true;
					int y = 0;
					int maxWidth = 0;
					foreach (TreeNodeAdv node in nodes)
					{
						if (node.Tree == this)
						{
							int x = 0;
							int height = _rowLayout.GetRowBounds(node.Row).Height;
							foreach (NodeControl c in NodeControls)
							{
								Size s = c.GetActualSize(node, context);
								if (!s.IsEmpty)
								{
									int width = s.Width;
									rect = new Rectangle(x, y, width, height);
									x += (width + 1);
									context.Bounds = rect;
									c.Draw(node, context);
                                    if (UseColumns) //only show first column if using columns
                                        break;
								}
							}
							y += height;
							maxWidth = Math.Max(maxWidth, x);
						}
					}
					if (maxWidth > 0 && y > 0)
					{
						_dragBitmap = new Bitmap(maxWidth, y, PixelFormat.Format32bppArgb);
						using (Graphics tgr = Graphics.FromImage(_dragBitmap))
							tgr.DrawImage(bitmap, Point.Empty);
						BitmapHelper.SetAlphaChanelValue(_dragBitmap, 150);
					}
					else
						_dragBitmap = null;
				}
			}
		}
