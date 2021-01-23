     //Select all visible items in select region.
     Rect selectRect = new Rect(Canvas.GetLeft(selectionBox), Canvas.GetTop(selectionBox),
                    (Canvas.GetLeft(selectionBox) + selectionBox.Width), (Canvas.GetTop(selectionBox) + selectionBox.Height));
     RectangleGeometry rr = new RectangleGeometry(selectRect);
     foreach (CustomElement elt in mainList.Items)
     {
      ListViewItem item = mainList.ItemContainerGenerator.ContainerFromItem(elt) as ListViewItem;
      Rect r = LayoutInformation.GetLayoutSlot(item);
      if (r.IntersectsWith(selectRect))
            item.IsSelected = true;
      else
            item.IsSelected = false;
     }
