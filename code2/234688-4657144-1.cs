        public class MouseOver
        {
            public void mouseOver(TextBox txtTemp, ToolTip ttpTemp)
            {
                switch (txtTemp.Name)
                {
                    case "textBox1":
                        {
                            ttpTemp.AutoPopDelay = 2000;
                            ttpTemp.InitialDelay = 1000;
                            ttpTemp.ReshowDelay = 500;
                            ttpTemp.IsBalloon = true;
                            ttpTemp.SetToolTip(txtTemp, "Ex:01(Should be Numeric)");
                            ttpTemp.Show("Ex : 01(Should Be Numeric)", txtTemp, txtTemp.Width, txtTemp.Height / 10, 5000);
                        }
                        break;
                    case "txtDetail":
                        {
                            ttpTemp.AutoPopDelay = 2000;
                            ttpTemp.InitialDelay = 1000;
                            ttpTemp.ReshowDelay = 500;
                            ttpTemp.IsBalloon = true;
                            ttpTemp.SetToolTip(txtTemp, "Ex:01(Should be Numeric)");
                            ttpTemp.Show("Ex : 01(Should Be Numeric)", txtTemp, txtTemp.Width, txtTemp.Height / 10, 5000);
                        }
                        break;
                }
            }
        }
