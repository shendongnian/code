    public class ComboBoxEx : ComboBox
    {
        public ComboBoxEx()
        {
            base.DropDownStyle = ComboBoxStyle.DropDownList;
            base.DrawMode = DrawMode.OwnerDrawFixed;
        }
    
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            if(e.State == DrawItemState.Focus)
                e.DrawFocusRectangle();
            var index = e.Index;
            if(index < 0 || index >= Items.Count) return;
            var item = Items[index];
            string text = (item == null)?"(null)":item.ToString();
            using(var brush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                e.Graphics.DrawString(text, e.Font, brush, e.Bounds);
            }
        }
    }
