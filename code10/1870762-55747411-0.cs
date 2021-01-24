    public class MyButton : Button
    {
        Image[] images;
        Button[] custom;
        Color hilited = ColorTranslator.FromHtml("#64A4B3B6");
        int inside;
        public MyButton()
        {
            SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick | ControlStyles.UserMouse, true);
            Margin = new Padding(0);
            TextAlign = ContentAlignment.TopCenter;
            ImageAlign = ContentAlignment.TopLeft;
            TextImageRelation = TextImageRelation.ImageBeforeText;
            Font = new Font("Century Gothic", 11f, FontStyle.Bold);
            Size = new Size(200, 75);
            FlatStyle = FlatStyle.Flat;
            BackColor = Color.Transparent;
            FlatAppearance.MouseOverBackColor = hilited;
            FlatAppearance.BorderSize = 2;
            FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            images = new Image[] { Resources.cross, Resources.settings };
            custom = CustomButtons();
            for (int i = 0; i < 2; i++)
            {
                Controls.Add(custom[i]);
                Controls[i].MouseEnter += CommonEnter;
                Controls[i].MouseLeave += CommonLeave;
            }
            MouseEnter += CommonEnter;
            MouseLeave += CommonLeave;
        }
        private Button[] CustomButtons()
        {
            Button delete = new Button();
            delete.Name = "delete";
            delete.Location = new Point(this.Size.Width - 22, 2);
            delete.Size = new Size(20, 20);
            delete.FlatStyle = FlatStyle.Flat;
            delete.BackColor = Color.Transparent;
            delete.FlatAppearance.MouseOverBackColor = hilited;
            delete.FlatAppearance.BorderSize = 0;
            Button customize = new Button();
            customize.Name = "customize";
            customize.Location = new Point(delete.Left - 20, delete.Top);
            customize.Size = new Size(20, 20);
            customize.FlatStyle = FlatStyle.Flat;
            customize.BackColor = Color.Transparent;
            customize.FlatAppearance.MouseOverBackColor = hilited;
            customize.FlatAppearance.BorderSize = 0;
            return new Button[] { delete, customize };
        }
        void CommonEnter(object sender, EventArgs e)
        {
            if (inside++ == 0)
            {
                BackColor = hilited;
                custom[0].BackgroundImage = images[0];
                custom[1].BackgroundImage = images[1];
            }
        }
        void CommonLeave(object sender, EventArgs e)
        {
            if (--inside == 0)
            {
                BackColor = Color.Transparent;
                custom[0].BackgroundImage = null;
                custom[1].BackgroundImage = null;
            }
        }
    }
