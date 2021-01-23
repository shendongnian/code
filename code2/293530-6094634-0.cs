    var startColor = Color.FromArgb(241, 245, 251);
    var endColor = Color.FromArgb(204, 217, 234);
    
    using (var brGradient = new LinearGradientBrush(panel1.ClientRectangle, startColor, endColor, LinearGradientMode.Vertical))
    {
    	brGradient.Blend = new Blend
    			{
    				Factors = new[] { 1.0f, 0.1f, 0.0f },
    				Positions = new[] { 0.0f, 0.1f, 1.0f }
    			};
    	e.Graphics.FillRectangle(brGradient, panel1.ClientRectangle);
    }
