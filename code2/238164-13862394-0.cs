    public partial class CustomButtonsDialog : Form
    {
        private const int ButtonHeight = 24;
        private const int ButtonPadding = 6;
        private const int ButtonInnerPadding = 5;
        private const int MaxFormWidth = 700;
        private int buttonIndex = -1;
        public int ButtonIndex
        {
            get { return buttonIndex; }
            private set { buttonIndex = value; }
        }
        public static int ShowCustomButtonsDialog(string text, string title, params string[] buttonsText)
        {
            var dlg = new CustomButtonsDialog(text, title, buttonsText.ToList());
            dlg.ShowDialog();
            return dlg.ButtonIndex;
        }
        public static int ShowCustomButtonsDialog(string text, string title, List<string> buttonsText)
        {
            var dlg = new CustomButtonsDialog(text, title, buttonsText);
            dlg.ShowDialog();
            return dlg.ButtonIndex;
        }
        
        public CustomButtonsDialog()
        {
            InitializeComponent();
        }
        private CustomButtonsDialog(string text, string title, List<string> buttonsText)
        {
            InitializeComponent();
            Text = title;
            labelText.Text = text;
            // добавить кнопки
            var formWidth = ClientSize.Width;
            List<int> buttonWidths;            
            using (var gr = CreateGraphics())
            {
                buttonWidths = buttonsText.Select(b => (int)gr.MeasureString(b, Font).Width + 2 * ButtonInnerPadding).ToList();                
            }
            var totalButtonWd = buttonWidths.Sum() + (buttonWidths.Count - 1) * ButtonPadding;
            if (totalButtonWd > formWidth)
            {
                if (totalButtonWd <= MaxFormWidth)
                    Width = Width - ClientSize.Width + totalButtonWd + ButtonPadding * 2;
                else
                {// trim some buttons
                    Width = Width - ClientSize.Width + MaxFormWidth;
                    totalButtonWd = ClientSize.Width - ButtonPadding * 2;
                    var avgWidth = (totalButtonWd - (buttonsText.Count - 1) * ButtonPadding) / buttonsText.Count;
                    var sumThins = buttonWidths.Sum(w => w <= avgWidth ? w : 0);
                    var countThins = buttonWidths.Count(w => w <= avgWidth);
                    var countFat = buttonsText.Count - countThins;
                    var spareRoom = totalButtonWd - sumThins;
                    var fatWidth = (countThins == 0) || (countFat == 0)
                                       ? avgWidth
                                       : (spareRoom - (countThins - 1)*ButtonPadding)/countFat;
                    for (var i = 0; i < buttonWidths.Count; i++)
                        if (buttonWidths[i] > avgWidth) buttonWidths[i] = fatWidth;                    
                }
            }
            // buttons' Y-coords and height
            labelText.MaximumSize = new Size(totalButtonWd,
                labelText.MaximumSize.Height);
            var buttonTop = labelText.Bottom + ButtonPadding;
            var formHeight = buttonTop + ButtonHeight + ButtonPadding;
            Height = Height - ClientSize.Height + formHeight;
            // do make buttons
            var buttonLeft = ButtonPadding;
            var tag = 0;
            for (var i = 0; i < buttonWidths.Count; i++)
            {
                var button = new Button
                                 {
                                     Parent = this,
                                     Width = buttonWidths[i],
                                     Height = ButtonHeight,
                                     Left = buttonLeft,
                                     Top = buttonTop,
                                     Text = buttonsText[i],
                                     Tag = tag++
                                 };
                button.Click += ButtonClick;
                buttonLeft = button.Right + ButtonPadding;
                Controls.Add(button);
            }
        }
        private void ButtonClick(object sender, EventArgs e)
        {
            ButtonIndex = (int) ((Button) sender).Tag;
            Close();
        }
    }
