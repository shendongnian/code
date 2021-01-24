    protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                if (e.NewElement as CustomStackBorder != null)
                {
                    Background = ContextCompat.GetDrawable(this.Context, Resource.Drawable.StackLayoutBorder);
                    GradientDrawable bgShape = (GradientDrawable)this.Background;
                    bgShape.SetStroke(1, (e.NewElement as CustomStackBorder).BorderColor.ToAndroid());
                }
            }
        }
