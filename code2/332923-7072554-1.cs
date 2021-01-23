    public class BuddyListBox  : ListBox
    {
      int thisIndex = -1;
    
      public BuddyListBox()
      {
        this.DrawMode = DrawMode.OwnerDrawVariable;
      }
    
      protected override void OnDrawItem(DrawItemEventArgs e)
      {
        if (this.Items.Count > 0)
        {
          if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
          else
            e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
          e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds.Left, e.Bounds.Top);
          base.OnDrawItem(e);
        }
      }
    
      protected override void OnSelectedIndexChanged(EventArgs e)
      {
        base.OnSelectedIndexChanged(e);
        thisIndex = this.SelectedIndex;
        this.RecreateHandle();
      }
    
      protected override void OnMeasureItem(MeasureItemEventArgs e)
      {
        if (e.Index > -1)
        {
          if (e.Index == thisIndex)
            e.ItemHeight = 32;
          else
            e.ItemHeight = 16;
        }
        base.OnMeasureItem(e);
      }
    }
