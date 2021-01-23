        protected void ColorTextRanges(Color color)
        {
            SolidColorBrush brush = new SolidColorBrush( color );
            foreach ( var textRange in locatedInstances )
            {
                if ( textRange != null )
                {
                    textRange.ApplyPropertyValue( TextElement.BackgroundProperty,  brush);
                }
            }
       }
