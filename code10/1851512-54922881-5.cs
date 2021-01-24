    using System;
	using System.Windows.Forms;
	namespace WindowsFormsApp1
	{
		public partial class Form2 : Form
		{
			public Form2(Form1 form1)
			{
				form1.OnLedChanged += (object sender, Form1.LedEventArgs e) =>
				{
					bool isGreen = e.IsGreen;
					// Change the LED on Form2 accordingly
		            Pen blackPen = new Pen(Color.Black, 5);
                    e.Graphics.DrawEllipse(blackPen, 615, 513, 40, 40);
                    e.Graphics.FillEllipse(Brushes.Red, 615, 513, 40, 40);
                    if (isGreen)
                    {
                        e.Graphics.FillEllipse(Brushes.Green, 615, 513, 40, 40);
                    }    
				};
			}
		}
	}
