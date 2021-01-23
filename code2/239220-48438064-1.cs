    internal class TextBoxField : TableLayoutPanel
    {
        private readonly TextBox _textBox;
        public string Text
        {
            get => _textBox.Text;
            set => _textBox.Text = value;
        }
        public TextBoxField(string labelText)
        {
            var label = new Label { Text = labelText, AutoSize = true };
            var labelMargin = label.Margin;
            labelMargin.Top = 8;
            label.Margin = labelMargin;
            _textBox = new TextBox { Dock = DockStyle.Fill };
            AutoSize = true;
            ColumnCount = 2;
            RowCount = 1;
            ColumnStyles.Add(new ColumnStyle());
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            RowStyles.Add(new RowStyle());
            Controls.Add(label, 0, 0);
            Controls.Add(_textBox, 1, 0);
        }
    }
    internal class DateTimePickerField : TableLayoutPanel
    {
        private readonly DateTimePicker _dateTimePicker;
        public DateTime Value
        {
            get => _dateTimePicker.Value;
            set => _dateTimePicker.Value = value;
        }
        public DateTimePickerField(string labelText)
        {
            var label = new Label { Text = labelText, AutoSize = true };
            var labelMargin = label.Margin;
            labelMargin.Top = 8;
            label.Margin = labelMargin;
            _dateTimePicker = new DateTimePicker { Dock = DockStyle.Fill };
            AutoSize = true;
            ColumnCount = 2;
            RowCount = 1;
            ColumnStyles.Add(new ColumnStyle());
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            RowStyles.Add(new RowStyle());
            Controls.Add(label, 0, 0);
            Controls.Add(_dateTimePicker, 1, 0);
        }
    }
