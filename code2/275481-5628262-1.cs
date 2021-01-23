    class MixedCheckBox:Control
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(0, 0), Bounds, 
                Text, Font, false, 
                System.Windows.Forms.VisualStyles.CheckBoxState.MixedNormal);
        }
    }
