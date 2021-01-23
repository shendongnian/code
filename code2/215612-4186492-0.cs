      protected override void OnParentChanged(EventArgs e)
      {
         base.OnParentChanged(e);
         base.Parent.Paint += new PaintEventHandler(Parent_Paint);
      }
      private void Parent_Paint(object sender, PaintEventArgs e)
      {
        if (base.Enabled && string.IsNullOrEmpty(base.Text))
        {
           e.Graphics.DrawImage(requiredIcon, 0, 0);
        }
      }
