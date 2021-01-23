    public class MyForm : Form
    {
        public MyForm()
        {
            targetLabel = new Label()
            {
                Text = "&Label",
                TabIndex = 10,
                AutoSize = true,
                Location = new Point(12, 17),
            };
            // you don't even need to keep a reference to the control for the instance
            var hiddenControl = new CheckBox()
            {
                Text = String.Empty,
                TabIndex = 11,                     // immediately follows the target label
                TabStop = false,                   // make it so it cannot be tabbed to
                AutoSize = true,
                Location = new Point(-100, -100),  // place it somewhere not visible
            };
            hiddenControl.GotFocus += (sender, e) =>
                {   // simulate clicking on the target button
                    targetButton.Focus();
                    targetButton.PerformClick();
                };
            targetButton = new Button()
            {
                Text = "&Click",
                TabIndex = 20,
                AutoSize = true,
                Location = new Point(53, 12),
            };
            targetButton.Click += (sender, e) =>
                {
                    MessageBox.Show("Target Clicked!");
                };
            dummyButton = new Button()
            {
                Text = "&Another Button",
                TabIndex = 0,
                AutoSize = true,
                Location = new Point(134, 12),
            };
            dummyButton.Click += (sender, e) =>
            {
                MessageBox.Show("Another Button Clicked!");
            };
            this.Controls.Add(targetLabel);
            this.Controls.Add(hiddenControl);
            this.Controls.Add(targetButton);
            this.Controls.Add(dummyButton);
        }
        private Label targetLabel;
        private Button targetButton;
        private Button dummyButton;
    }
