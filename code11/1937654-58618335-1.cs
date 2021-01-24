    public class GradientViewRenderer : Xamarin.Forms.Platform.Android.ViewRenderer<GradientTest.GradientViewRender, View>
	{
		LinearLayout layout;
        Xamarin.Forms.Color[] gradientColors;
       
		double viewHeight;
		
		protected override void OnElementChanged(ElementChangedEventArgs<GradientTest.GradientViewRender> e)
		{
			base.OnElementChanged(e);
			if (Control == null)
			{
				layout = new LinearLayout(Application.Context);
				layout.SetBackgroundColor(Color.White);
			
                gradientColors = (Xamarin.Forms.Color[])e.NewElement.GradientColors;
				
				viewHeight = (double)e.NewElement.ViewHeight;
				
				CreateLayout();
			}
			if (e.OldElement != null)
			{
				// Unsubscribe from event handlers and cleanup any resources
			}
			if (e.NewElement != null)
			{
				// Configure the control and subscribe to event handlers
				gradientColors = (Xamarin.Forms.Color[])e.NewElement.GradientColors;
				
				viewHeight = (double)e.NewElement.ViewHeight;
				
				CreateLayout();
			}
		}
		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			if (e.PropertyName == GradientViewRender.ViewHeightProperty.PropertyName)
			{
				this.viewHeight = (double)this.Element.ViewHeight;
				CreateLayout();
			}
			
			else if (e.PropertyName == GradientViewRender.GradientColorsProperty.PropertyName)
			{
                this.gradientColors = (Xamarin.Forms.Color[])this.Element.GradientColors;
				CreateLayout();
			}
			
			
		}
		private void CreateLayout()
		{
			layout.SetMinimumWidth((int)viewWidth);
			layout.SetMinimumHeight((int)viewHeight);
			CreateGradient();
            SetNativeControl(layout);
		}
		public void CreateGradient()
		{
			//Need to convert the colors to Android Color objects
			int[] androidColors = new int[gradientColors.Count()];
			for (int i = 0; i < gradientColors.Count(); i++)
			{
                Xamarin.Forms.Color temp = gradientColors[i];
                androidColors[i] = temp.ToAndroid();
			}
			GradientDrawable gradient = new GradientDrawable(GradientDrawable.Orientation.LeftRight, androidColors);
			if (roundCorners)
                gradient.SetCornerRadii(new float[] { cornerRadius, cornerRadius, cornerRadius, cornerRadius, cornerRadius, cornerRadius, cornerRadius, cornerRadius });
			layout.SetBackground(gradient);
		}
	}
