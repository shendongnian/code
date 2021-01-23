    public string LabelText
    {
        set
        {
            _label.Text = value;
            using (Graphics g = CreateGraphics()) {
                _label.Width = (int)g.MeasureString(_label.Text, _label.Font).Width;
            }
        }
   }
