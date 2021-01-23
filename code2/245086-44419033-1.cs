    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    public class CircularProgressBar : Control
    {
	    /*  CREDITS:
	     *  Autor: Sajjad Arif Gul / October 12, 2016 / C#, Source Codes
	     *  https://www.csharpens.com/c-sharp/circular-progress-bar-in-c-sharp-windows-form-applications-23/
	     *  Modified by Jhollman Chacon, 2017 */
	#region Enums
	public enum _ProgressShape
	{
		Round,
		Flat
	}
	#endregion
	#region Variables
	private long _Value;
	private long _Maximum = 100;
	private Color _ProgressColor1 = Color.Orange;
	private Color _ProgressColor2 = Color.Orange;
	private Color _LineColor = Color.Silver;
	private _ProgressShape ProgressShapeVal;
	#endregion
	#region Custom Properties
	public long Value
	{
		get { return _Value; }
		set
		{
			if (value > _Maximum)
				value = _Maximum;
			_Value = value;
			Invalidate();
		}
	}
	public long Maximum
	{
		get { return _Maximum; }
		set
		{
			if (value < 1)
				value = 1;
			_Maximum = value;
			Invalidate();
		}
	}
	public Color ProgressColor1
	{
		get { return _ProgressColor1; }
		set
		{
			_ProgressColor1 = value;
			Invalidate();
		}
	}
	public Color ProgressColor2
	{
		get { return _ProgressColor2; }
		set
		{
			_ProgressColor2 = value;
			Invalidate();
		}
	}
	public Color LineColor
	{
		get { return _LineColor; }
		set
		{
			_LineColor = value;
			Invalidate();
		}
	}
	public _ProgressShape ProgressShape
	{
		get { return ProgressShapeVal; }
		set
		{
			ProgressShapeVal = value;
			Invalidate();
		}
	}
	#endregion
	#region EventArgs
	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		SetStandardSize();
	}
	protected override void OnSizeChanged(EventArgs e)
	{
		base.OnSizeChanged(e);
		SetStandardSize();
	}
	protected override void OnPaintBackground(PaintEventArgs p)
	{
		base.OnPaintBackground(p);
	}
	#endregion
	#region Methods
	public CircularProgressBar()
	{
		Size = new Size(130, 130);
		Font = new Font("Segoe UI", 15);
		MinimumSize = new Size(100, 100);
		DoubleBuffered = true;
		Value = 57;
		ProgressShape = _ProgressShape.Flat;
		this.ForeColor = Color.DimGray;
	}
	private void SetStandardSize()
	{
		int _Size = Math.Max(Width, Height);
		Size = new Size(_Size, _Size);
	}
	public void Increment(int Val)
	{
		this._Value += Val;
		Invalidate();
	}
	public void Decrement(int Val)
	{
		this._Value -= Val;
		Invalidate();
	}
	#endregion
	#region Events
	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		using (Bitmap bitmap = new Bitmap(this.Width, this.Height))
		{
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.Clear(this.BackColor);
				// Dibuja la Linea
				using (Pen pen2 = new Pen(LineColor))
				{
					graphics.DrawEllipse(pen2, 0x18 - 6, 0x18 - 6, (this.Width - 0x30) + 12, (this.Height - 0x30) + 12);
				}
				//Dibuja la Barra de Progreso
				using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, this._ProgressColor1, this._ProgressColor2, LinearGradientMode.ForwardDiagonal))
				{
					using (Pen pen = new Pen(brush, 14f))
					{
						switch (this.ProgressShapeVal)
						{
							case _ProgressShape.Round:
								pen.StartCap = LineCap.Round;
								pen.EndCap = LineCap.Round;
								break;
							case _ProgressShape.Flat:
								pen.StartCap = LineCap.Flat;
								pen.EndCap = LineCap.Flat;
								break;
						}
						//Aqui se dibuja el Progreso
						graphics.DrawArc(pen, 0x12, 0x12, (this.Width - 0x23) - 2, (this.Height - 0x23) - 2, -90, (int)Math.Round((double)((360.0 / ((double)this._Maximum)) * this._Value)));
					}
				}
				//Dibuja el Texto de Progreso:
				Brush FontColor = new SolidBrush(this.ForeColor);
				SizeF MS = graphics.MeasureString(Convert.ToString(Convert.ToInt32((100 / _Maximum) * _Value)), Font);
				graphics.DrawString(Convert.ToString(Convert.ToInt32((100 / _Maximum) * _Value)), Font, FontColor, Convert.ToInt32(Width / 2 - MS.Width / 2), Convert.ToInt32(Height / 2 - MS.Height / 2));
				e.Graphics.DrawImage(bitmap, 0, 0);
				graphics.Dispose();
				bitmap.Dispose();
			}
		}
	} 
	#endregion
    }
