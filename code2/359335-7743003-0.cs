    void Thumb_DragDeltaEvent(object sender, RoutedEventArgs e)
        {
            UIElement src = e.Source as UIElement ;
            if (src != null)
            {                
                Point srcPositionTopLeft = new Point(Canvas.GetLeft(src), Canvas.GetTop(src));
                Point srcPositionBottomRight = new Point(srcPositionTopLeft.X + src.ActualWidth, srcPositionTopLeft.Y + ActualHeight);
                Rect srcRect = new Rect(srcPositionTopLeft, srcPositionBottomRight);
                Rect transformedSrcRect = src.TransformToAncestor(WorkflowDesignCanvas).TransformBounds(srcRect);
                
                Point trgPositionTopLeft = new Point(Canvas.GetLeft(JoinLineConnectorRect), Canvas.GetTop(JoinLineConnectorRect));
                Point trgPositionBottomRight = new Point(trgPositionTopLeft.X + JoinLineConnectorRect.ActualWidth, trgPositionTopLeft.Y + JoinLineConnectorRect.ActualHeight);
                Rect trgRect = new Rect(srcPositionTopLeft, srcPositionBottomRight);
                Rect transformedTrgRect = JoinLineConnectorRect.TransformToAncestor(WorkflowDesignCanvas).TransformBounds(trgRect);
                if (transformedSrcRect.Contains(transformedTrgRect) ||
                    transformedSrcRect.IntersectsWith(transformedTrgRect))
                {
                    //drag is over element
                }
            }
        }
