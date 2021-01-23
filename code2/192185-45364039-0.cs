     if (e.Index < 0) return;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          Color.Yellow);
      e.DrawBackground();
      //This is my modification below:
      e.Graphics.DrawString(ctListViewProcess.Items.Cast<entMyEntity>().Select(c => c.strPropertyName).ElementAt(e.Index), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
      e.DrawFocusRectangle();
