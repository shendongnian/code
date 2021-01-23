    using System.Windows.Forms;
    using System.Drawing;
    public class MyForm : Form {
        public MyForm() {
            targetLabel = new Label() {
                Text = "&Label",
                TabIndex = 10,
                AutoSize = true,
                Location = new Point(12, 17),
            };
            // you don't need to keep an instance variable
            var hiddenControl = new CheckBox()
            {
                Text = String.Empty,
                TabIndex = 11,                    // immediately follows target label
                TabStop = false,                  // prevent tabbing to control
                Location = new Point(-100, -100), // put somewhere not visible
            };
            hiddenControl.GotFocus += (sender, e) => {
                // simulate clicking on the target button
                targetButton.Focus();
                targetButton.PerformClick();
            };
            targetButton = new Button() {
                Text = "&Click",
                TabIndex = 20,
                AutoSize = true,
                Location = new Point(53, 12),
            };
            targetButton.Click += (sender, e) => {
                MessageBox.Show("Target Clicked!");
            };
            dummyButton = new Button() {
                Text = "&Another Button",
                TabIndex = 0,
                AutoSize = true,
                Location = new Point(134, 12),
            };
            dummyButton.Click += (sender, e) => {
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
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyForm());
        }
    }
