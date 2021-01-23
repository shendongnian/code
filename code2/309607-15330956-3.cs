	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;
	using System.Drawing.Drawing2D;
	namespace WindowsFormsApplication1
	{
		public partial class Form1 : Form
		{
			public Form1()
			{
				InitializeComponent();
			}
			private void Form1_Paint(object sender, PaintEventArgs e)
			{
				e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				int Offset = 25;
				int BoxSize = 100;
				int GlintSize = (int)((double)BoxSize * ((double)3 / (double)4));
				Rectangle Circle = new Rectangle(Offset, Offset, BoxSize, BoxSize);
				Rectangle Glint = new Rectangle(Offset, Offset, GlintSize, GlintSize);
				//Debug
				//e.Graphics.FillRectangle(new SolidBrush(Color.Red), Circle);
				//e.Graphics.FillRectangle(new SolidBrush(Color.BlueViolet), Glint);
				//Generate Glint
				GraphicsPath P = new GraphicsPath();
				P.AddEllipse(Glint);
				PathGradientBrush FlareBrush = new PathGradientBrush(P);
				FlareBrush.CenterColor = Color.FromArgb(255, 255, 255, 255);
				Color[] colors = { Color.Transparent };
				FlareBrush.SurroundColors = colors;
				e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(255, 255, 0, 0)), Circle);
				e.Graphics.FillEllipse(FlareBrush, Glint);
				e.Graphics.DrawEllipse(new Pen(new SolidBrush(Color.Black), 1F), Circle);
			}
		}
	}
