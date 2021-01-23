    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using System.Text.RegularExpressions;
    
    namespace Common
    {
        // Loosely based on: https://www.codeproject.com/Articles/17253/A-Custom-Message-Box
        class MsgBox : Form
        {
            private Panel _plHeader = new Panel();
            private Panel _plFooter = new Panel();
            private Panel _plIcon = new Panel();
            private PictureBox _picIcon = new PictureBox();
            private FlowLayoutPanel _flpButtons = new FlowLayoutPanel();
            private Label _lblMessage;
    
            private MsgBox()
            {
                FormBorderStyle = FormBorderStyle.FixedDialog;
                BackColor = Color.White;
                StartPosition = FormStartPosition.CenterScreen;
                MinimizeBox = false;
                MaximizeBox = false;
                ShowIcon = false;
                Width = 400;
    
                _lblMessage = new Label();
                _lblMessage.Font = new Font("Segoe UI", 10);
                _lblMessage.Dock = DockStyle.Fill;
                _lblMessage.TextAlign = ContentAlignment.MiddleLeft;
    
                _flpButtons.FlowDirection = FlowDirection.RightToLeft;
                _flpButtons.Dock = DockStyle.Fill;
    
                //_plHeader.FlowDirection = FlowDirection.TopDown;
                _plHeader.Dock = DockStyle.Fill;
                _plHeader.Padding = new Padding(20);
                _plHeader.Controls.Add(_lblMessage);
    
                _plFooter.Dock = DockStyle.Bottom;
                _plFooter.BackColor = Color.FromArgb(240, 240, 240);
                _plFooter.Padding = new Padding(10);
                _plFooter.Height = 60;
                _plFooter.Controls.Add(_flpButtons);
    
                _picIcon.Location = new Point(30, 50);
    
                _plIcon.Dock = DockStyle.Left;
                _plIcon.Padding = new Padding(20);
                _plIcon.Width = 70;
                _plIcon.Controls.Add(_picIcon);
    
                Controls.Add(_plHeader);
                Controls.Add(_plIcon);
                Controls.Add(_plFooter);
            }
    
            public static DialogResult Show(IWin32Window owner, string message, string title = null, MessageBoxButtons? buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
            {
                var msgBox = Create(message, title, buttons, icon);
                return msgBox.ShowDialog(owner);
            }
    
            public static DialogResult Show(string message, string title = null, MessageBoxButtons? buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
            {
                var msgBox = Create(message, title, buttons, icon);
                return msgBox.ShowDialog();
            }
    
            public static MsgBox Create(string message, string title = null, MessageBoxButtons? buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
            {
                var msgBox = new MsgBox();
                msgBox.Init(message, title, buttons, icon);
                return msgBox;
            }
    
            void Init(string message, string title, MessageBoxButtons? buttons, MessageBoxIcon icon)
            {
                _lblMessage.Text = message;
                Text = title;
                InitButtons(buttons);
                InitIcon(icon);
                Size = MessageSize(message);
            }
    
            void InitButtons(MessageBoxButtons? buttons)
            {
                if (!buttons.HasValue)
                    return;
    
                switch (buttons)
                {
                    case MessageBoxButtons.AbortRetryIgnore:
                        AddButton("Ignore");
                        AddButton("Retry");
                        AddButton("Abort");
                        break;
    
                    case MessageBoxButtons.OK:
                        AddButton("OK");
                        break;
    
                    case MessageBoxButtons.OKCancel:
                        AddButton("Cancel");
                        AddButton("OK");
                        break;
    
                    case MessageBoxButtons.RetryCancel:
                        AddButton("Cancel");
                        AddButton("Retry");
                        break;
    
                    case MessageBoxButtons.YesNo:
                        AddButton("No");
                        AddButton("Yes");
                        break;
    
                    case MessageBoxButtons.YesNoCancel:
                        AddButton("Cancel");
                        AddButton("No");
                        AddButton("Yes");
                        break;
                }
            }
    
            void InitIcon(MessageBoxIcon icon)
            {
                switch (icon)
                {
                    case MessageBoxIcon.None:
                        _picIcon.Hide();
                        break;
                    case MessageBoxIcon.Exclamation:
                        _picIcon.Image = SystemIcons.Exclamation.ToBitmap();
                        break;
    
                    case MessageBoxIcon.Error:
                        _picIcon.Image = SystemIcons.Error.ToBitmap();
                        break;
    
                    case MessageBoxIcon.Information:
                        _picIcon.Image = SystemIcons.Information.ToBitmap();
                        break;
    
                    case MessageBoxIcon.Question:
                        _picIcon.Image = SystemIcons.Question.ToBitmap();
                        break;
                }
    
                _picIcon.Width = _picIcon.Image.Width;
                _picIcon.Height = _picIcon.Image.Height;
            }
    
            private void ButtonClick(object sender, EventArgs e)
            {
                Button btn = (Button)sender;
    
                switch (btn.Text)
                {
                    case "Abort":
                        DialogResult = DialogResult.Abort;
                        break;
    
                    case "Retry":
                        DialogResult = DialogResult.Retry;
                        break;
    
                    case "Ignore":
                        DialogResult = DialogResult.Ignore;
                        break;
    
                    case "OK":
                        DialogResult = DialogResult.OK;
                        break;
    
                    case "Cancel":
                        DialogResult = DialogResult.Cancel;
                        break;
    
                    case "Yes":
                        DialogResult = DialogResult.Yes;
                        break;
    
                    case "No":
                        DialogResult = DialogResult.No;
                        break;
                }
    
                Close();
            }
    
            private static Size MessageSize(string message)
            {
                int width=350;
                int height = 230;
    
                SizeF size = TextRenderer.MeasureText(message, new Font("Segoe UI", 10));
    
                if (message.Length < 150)
                {
                    if ((int)size.Width > 350)
                    {
                        width = (int)size.Width;
                    }
                }
                else
                {
                    string[] groups = (from Match m in Regex.Matches(message, ".{1,180}") select m.Value).ToArray();
                    int lines = groups.Length+1;
                    width = 700;
                    height += (int)(size.Height+10) * lines;
                }
                return new Size(width, height);
            }
    
            private void AddButton(string caption)
            {
                var btn = new Button();
                btn.Text = caption;
                btn.Font = new Font("Segoe UI", 8);
                btn.BackColor = Color.FromArgb(225, 225, 225);
                btn.Padding = new Padding(3);
                btn.Height = 30;
                btn.Click += ButtonClick;
                _flpButtons.Controls.Add(btn);
            }
        }
    }
