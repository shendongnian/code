    using System;
	using System.Windows.Forms;
	namespace WindowsFormsApp1
	{
		public partial class Form2 : Form
		{
			private bool isGreen;
			public Form2(Form1 form1)
			{
				form1.OnLedChanged += (object sender, Form1.LedEventArgs e) =>
				{
					this.isGreen = e.IsGreen;
					this.Refresh();                
				};
			}
			protected override void OnPaint(PaintEventArgs e)
			{
				base.OnPaint(e);
				Pen blackPen = new Pen(Color.Black, 5);
				e.Graphics.DrawEllipse(blackPen, 10, 10, 40, 40);
				e.Graphics.FillEllipse(Brushes.Red, 10, 10, 40, 40);
				if (this.isGreen)
				{
					e.Graphics.FillEllipse(Brushes.Green, 10, 10, 40, 40);
				}
			}
		}
	}
