    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    public class SizeablePanel : Panel {
      private const int cGripSize = 20;
      private bool mDragging;
      private Point mDragPos;
    
      public SizeablePanel() {
        this.DoubleBuffered = true;
        this.SetStyle(ControlStyles.ResizeRedraw, true);
        this.BackColor = Color.White;
      }
    
      protected override void OnPaint(PaintEventArgs e) {
        ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor,
          new Rectangle(this.ClientSize.Width - cGripSize, this.ClientSize.Height - cGripSize, cGripSize, cGripSize));
        base.OnPaint(e);
      }
    
      private bool IsOnGrip(Point pos) {
        return pos.X >= this.ClientSize.Width - cGripSize &&
               pos.Y >= this.ClientSize.Height - cGripSize;
      }
    
      protected override void OnMouseDown(MouseEventArgs e) {
        mDragging = IsOnGrip(e.Location);
        mDragPos = e.Location;
        base.OnMouseDown(e);
      }
    
      protected override void OnMouseUp(MouseEventArgs e) {
        mDragging = false;
        base.OnMouseUp(e);
      }
    
      protected override void OnMouseMove(MouseEventArgs e) {
        if (mDragging) {
          this.Size = new Size(this.Width + e.X - mDragPos.X,
            this.Height + e.Y - mDragPos.Y);
          mDragPos = e.Location;
        }
        else if (IsOnGrip(e.Location)) this.Cursor = Cursors.SizeNWSE;
        else this.Cursor = Cursors.Default;
        base.OnMouseMove(e);
      }
    }
