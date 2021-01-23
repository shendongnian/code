    public class TestForm : Form
    {
        public TestForm()
        {
            this.Text = "Test Form";
            var panel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                BorderStyle = BorderStyle.FixedSingle,
            };
            var button = new Button
            {
                Text = "Button!",
                Enabled = false,
            };
            var cb = new CheckBox
            {
                Text = "Buton Enabled",
                Checked = false,
            };
            panel.Click += (sender, e) => MessageBox.Show("Panel clicked!");
            button.Click += (sender, e) => MessageBox.Show("Button clicked!");
            this.Click += (sender, e) => MessageBox.Show("Form clicked!");
            cb.CheckedChanged += (sender, e) => button.Enabled = cb.Checked;
            panel.Controls.Add(button);
            panel.Controls.Add(cb);
            this.Controls.Add(panel);
        }
    }
