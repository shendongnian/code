    public class ThemeBaseUI : ThemeContainer154
    {
        private string _UnderInfo = "";
        public string SoftwareInfo
        {
            get { return _UnderInfo; }
            set
            {
                _UnderInfo = value;
                Invalidate();
            }
        }
        public ThemeBaseUI()
        {
            BackColor = Color.WhiteSmoke;
            Font = new Font("Segoe UI", 10);
            SetColor("Border", Color.FromArgb(0, 114, 198));
            SetColor("Text", Color.White);
            _UnderInfo = GetCopyright() + "     " + GetCompany();
        }
        Color Border;
        Brush TextBrush;
        protected override void ColorHook()
        {
            Border = GetColor("Border");
            TextBrush = GetBrush("Text");
        }
        private string GetCopyright()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            object[] obj = asm.GetCustomAttributes(false);
            foreach (object o in obj)
            {
                if (o.GetType() == typeof(System.Reflection.AssemblyCopyrightAttribute))
                {
                    AssemblyCopyrightAttribute aca = (AssemblyCopyrightAttribute)o;
                    return aca.Copyright;
                }
            }
            return string.Empty;
        }
        private string GetCompany()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            object[] obj = asm.GetCustomAttributes(false);
            foreach (object o in obj)
            {
                if (o.GetType() == typeof(System.Reflection.AssemblyCompanyAttribute))
                {
                    AssemblyCompanyAttribute aca = (AssemblyCompanyAttribute)o;
                    return aca.Company;
                }
            }
            return string.Empty;
        }
        protected override void PaintHook()
        {
            //Form
            G.Clear(Border);
            G.FillRectangle(new SolidBrush(BackColor), new Rectangle(0, 36, Width, Height - 36));
            G.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, Height - 20, Width, Height));
            G.DrawString(FindForm().Text, Font, TextBrush, new Point(35, 9));
            G.DrawIcon(FindForm().Icon, new Rectangle(10, 10, 16, 16));
            G.DrawString(_UnderInfo, Font, new SolidBrush(Color.DimGray), new Point(5, Height - 19));
            //Close
            //Minimise
            //Minimise
            //G.DrawRectangle(new Pen(Color.White, 2), new Rectangle(Width - 73, 0, 24, 24));
            WindowStateClose WSC = new WindowStateClose();
            WSC.Location = new Point(Width - 21, 0);
            WSC.Size = new Size(20, 20);
            Controls.Add(WSC);
            WindowStateMin WSMa = new WindowStateMin();
            WSMa.Location = new Point(Width - 59, 0);
            WSMa.Size = new Size(34, 23);
            Controls.Add(WSMa);
            Size SetSize = new Size(Width, Height);
            MinimumSize = SetSize;
            MaximumSize = SetSize;
        }
        private class WindowStateClose : ThemeControl154
        {
            public WindowStateClose()
            {
                //Close Button
                SetColor("Cross", Color.White);
                SetColor("Button", Color.FromArgb(0, 114, 198));
                SetColor("Border", Color.White);
            }
            Color ButtonColor;
            Pen Border, Cross;
            protected override void ColorHook()
            {
                Cross = GetPen("Cross", 2);
                Border = GetPen("Border");
                ButtonColor = GetColor("Button");
            }
            protected override void PaintHook()
            {
                G.Clear(ButtonColor);
                G.SmoothingMode = SmoothingMode.AntiAlias;
                switch (State)
                {
                    case MouseState.None:
                        G.DrawEllipse(Cross, new Rectangle(Width - 20, 4, 15, 15));
                        break;
                    case MouseState.Over:
                        G.DrawEllipse(Cross, new Rectangle(Width - 20, 4, 15, 15));
                        G.FillEllipse(new SolidBrush(Color.White), new Rectangle(Width - 17, 7, 9, 9));
                        break;
                    case MouseState.Down:
                        G.DrawEllipse(Cross, new Rectangle(Width - 20, 4, 15, 15));
                        G.FillEllipse(new SolidBrush(Color.White), new Rectangle(Width - 16, 8, 7, 7));
                        Environment.Exit(0);
                        break;
                }
            }
        }
        private class WindowStateMin : ThemeControl154
        {
            public WindowStateMin()
            {
                //Close Button
                SetColor("Min", Color.White);
                SetColor("Button", Color.FromArgb(0, 114, 198));
                SetColor("Border", Color.White);
            }
            Color ButtonColor;
            Pen Border, Min;
            protected override void ColorHook()
            {
                Min = GetPen("Min", 3);
                Border = GetPen("Border");
                ButtonColor = GetColor("Button");
            }
            protected override void PaintHook()
            {
                G.Clear(ButtonColor);
                G.SmoothingMode = SmoothingMode.AntiAlias;
                switch (State)
                {
                    case MouseState.None:
                        G.DrawLine(Min, new Point(Width - 44, 12), new Point(20, 12));
                        break;
                    case MouseState.Over:
                        G.DrawLine(Min, new Point(Width - 44, 6), new Point(20, 6));
                        G.DrawLine(Min, new Point(Width - 44, 12), new Point(20, 12));
                        G.DrawLine(Min, new Point(Width - 44, 18), new Point(20, 18));
                        break;
                    case MouseState.Down:
                        G.DrawLine(Min, new Point(Width - 44, 12), new Point(20, 12));
                        this.FindForm().WindowState = FormWindowState.Minimized;
                        break;
                }
            }
        }
    }
