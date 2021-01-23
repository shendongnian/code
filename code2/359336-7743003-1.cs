    void Thumb_DragDeltaEvent(object sender, RoutedEventArgs e)
        {
            UIElement src = e.Source as UIElement ;
            if (src != null)
            {                
                Point srcPositionTopLeft = new Point(Canvas.GetLeft(src), Canvas.GetTop(src));
                Point srcPositionBottomRight = new Point(srcPositionTopLeft.X + src.ActualWidth, srcPositionTopLeft.Y + ActualHeight);
                Rect srcRect = new Rect(srcPositionTopLeft, srcPositionBottomRight);
                Rect transformedSrcRect = src.TransformToAncestor(this.Parent).TransformBounds(srcRect);
                
                Point trgPositionTopLeft = new Point(Canvas.GetLeft(this), Canvas.GetTop(this));
                Point trgPositionBottomRight = new Point(trgPositionTopLeft.X + this.ActualWidth, trgPositionTopLeft.Y + this.ActualHeight);
                Rect trgRect = new Rect(srcPositionTopLeft, srcPositionBottomRight);
                Rect transformedTrgRect = this.TransformToAncestor(this.Parent).TransformBounds(trgRect);
                if (transformedSrcRect.Contains(transformedTrgRect) ||
                    transformedSrcRect.IntersectsWith(transformedTrgRect))
                {
                    //drag is over element
                }
            }
        }
