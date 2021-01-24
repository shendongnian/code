     protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);
            Background = ContextCompat.GetDrawable(this.Context, Resource.Drawable.StackLayoutBorder);
            GradientDrawable bgShape = (GradientDrawable)this.Background;
            bgShape.SetStroke(1, Android.Graphics.Color.ParseColor("BorderColor"));
        }
