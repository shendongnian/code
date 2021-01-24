    public class GradientViewRender : View
    {
        public static readonly BindableProperty GradientColorsProperty = BindableProperty.Create<GradientViewRender, Color[]>(p => p.GradientColors, new Color[]{Color.White} );
		public Color[] GradientColors
		{
			get { return (Color[])base.GetValue(GradientColorsProperty); }
			set { base.SetValue(GradientColorsProperty, value); }
		}
		
		public static readonly BindableProperty ViewHeightProperty = BindableProperty.Create<GradientViewRender, double>(p => p.ViewHeight, 0);
		public double ViewHeight
		{
			get { return (double)base.GetValue(ViewHeightProperty); }
			set { base.SetValue(ViewHeightProperty, value); }
		}
		
		public static readonly BindableProperty LeftToRightProperty = BindableProperty.Create<GradientViewRender, bool>(p => p.LeftToRight, true);
		public bool LeftToRight
		{
			get { return (bool)base.GetValue(LeftToRightProperty); }
			set { base.SetValue(LeftToRightProperty, value); }
		}
    }
