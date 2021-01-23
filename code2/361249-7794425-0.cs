        protected override void OnRender(DrawingContext drawingContext)
        {
            this.formattedToolTip = new FormattedText(
                    (string)this.TextProperty,
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface(
                         new FontFamily("Arial"),
                         FontStyles.Normal,
                         FontWeights.Bold,
                         FontStretches.Normal),
                    11,
                    new SolidColorBrush(Colors.Black));
            drawingContext.DrawText(
                    this.formattedToolTip,
                    new Point(10, 10)); //// Margin of 10 pixels from top and left.
        }
