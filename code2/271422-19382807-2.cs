    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    public class TransparentPictureBox
    {
    	private Timer withEventsField_refresher;
    	private Timer refresher {
    		get { return withEventsField_refresher; }
    		set {
    			if (withEventsField_refresher != null) {
    				withEventsField_refresher.Tick -= refresher_Tick;
    			}
    			withEventsField_refresher = value;
    			if (withEventsField_refresher != null) {
    				withEventsField_refresher.Tick += refresher_Tick;
    			}
    		}
    	}
    
    	private Image _image = null;
    
    	public TransparentPictureBox()
    	{
    		// This call is required by the designer.
    		InitializeComponent();
    
    		// Add any initialization after the InitializeComponent() call.
    		refresher = new Timer();
    		//refresher.Tick += New EventHandler(AddressOf Me.TimerOnTick)
    		refresher.Interval = 50;
    		refresher.Start();
    
    	}
    
    	protected override CreateParams CreateParams {
    		get {
    			CreateParams cp = base.CreateParams;
    			cp.ExStyle = cp.ExStyle | 0x20;
    			return cp;
    		}
    	}
    
    	protected override void OnMove(EventArgs e)
    	{
    		base.OnMove(e);
    		base.RecreateHandle();
    	}
    
    	protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    	{
    		base.OnPaint(e);
    
    		//Add your custom paint code here
    		if (_image != null) {
    			e.Graphics.DrawImage(_image, Convert.ToInt32(Width / 2) - Convert.ToInt32(_image.Width / 2), Convert.ToInt32(Height / 2) - Convert.ToInt32(_image.Height / 2));
    		}
    	}
    
    
    	protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
    	{
    		// Paint background with underlying graphics from other controls
    		base.OnPaintBackground(e);
    		Graphics g = e.Graphics;
    
    		if (Parent != null) {
    			// Take each control in turn
    			int index = Parent.Controls.GetChildIndex(this);
    			for (int i = Parent.Controls.Count - 1; i >= index + 1; i += -1) {
    				Control c = Parent.Controls(i);
    
    				// Check it's visible and overlaps this control
    				if (c.Bounds.IntersectsWith(Bounds) && c.Visible) {
    					// Load appearance of underlying control and redraw it on this background
    					Bitmap bmp = new Bitmap(c.Width, c.Height, g);
    					c.DrawToBitmap(bmp, c.ClientRectangle);
    					g.TranslateTransform(c.Left - Left, c.Top - Top);
    					g.DrawImageUnscaled(bmp, Point.Empty);
    					g.TranslateTransform(Left - c.Left, Top - c.Top);
    					bmp.Dispose();
    				}
    			}
    		}
    	}
    
    	public Image Image {
    		get { return _image; }
    		set {
    			_image = value;
    			base.RecreateHandle();
    		}
    	}
    
    	private void refresher_Tick(object sender, System.EventArgs e)
    	{
    		base.RecreateHandle();
    		refresher.Stop();
    	}
    }
