	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;
	using System.Drawing;
	using System.Drawing.Drawing2D;
	namespace WindowsFormsApplication1
	{
		public class ColouredRadioButton : RadioButton
		{
			// Fields
			private Color m_OnColour;
			private Color m_OffColour;
			private Rectangle m_glint;
			private Rectangle m_circle;
			private PathGradientBrush m_flareBrush;
			private Pen m_outline;
			// Properties
			public Color OnColour
			{
				get
				{
					return m_OnColour;
				}
				set
				{
					if ((value == Color.White) || (value == Color.Transparent))
						m_OnColour = Color.Empty;
					else
						m_OnColour = value;
				}
			}
			public Color OffColour
			{
				get
				{
					return m_OffColour;
				}
				set
				{
					if ((value == Color.White) || (value == Color.Transparent))
						m_OffColour = Color.Empty;
					else
						m_OffColour = value;
				}
			}
			// Constructor
			public ColouredRadioButton()
			{
				// Init
				m_circle = new Rectangle(2, 5, 7, 7 /*Magic Numbers*/);
				m_glint = new Rectangle(3, 6, 4, 4  /*Magic Numbers*/);
				m_outline = new Pen(new SolidBrush(Color.Black), 1F /*Magic Numbers*/);
				// Generate Glint
				GraphicsPath Path = new GraphicsPath();
				Path.AddEllipse(m_glint);
				m_flareBrush = new PathGradientBrush(Path);
				m_flareBrush.CenterColor = Color.White;
				m_flareBrush.SurroundColors = new Color[] { Color.Transparent };
				m_flareBrush.FocusScales = new PointF(0.5F, 0.5F/*Magic Numbers*/);
				// Allows for Overlaying
				SetStyle(ControlStyles.SupportsTransparentBackColor, true);
				BackColor = Color.Transparent;
			}
			// Methods
			protected override void OnPaint(PaintEventArgs e)
			{
				// Init
				Graphics g = e.Graphics;
				g.Clear(Color.Transparent);
				base.OnPaint(e);
				g.SmoothingMode = SmoothingMode.AntiAlias;
				// Overlay Graphic
				if (this.Checked)
				{
					if (OnColour != Color.Empty)
					{
						g.FillEllipse(new SolidBrush(OnColour), m_circle);
						g.FillEllipse(m_flareBrush, m_glint);
						g.DrawEllipse(m_outline, m_circle);
					}
				}
				else
				{
					if (OffColour != Color.Empty)
					{
						g.FillEllipse(new SolidBrush(OffColour), m_circle);
						g.FillEllipse(m_flareBrush, m_glint);
						g.DrawEllipse(m_outline, m_circle);
					}
				}
			}
		}
	}
