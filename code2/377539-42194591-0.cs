     class OptionalSegmentedControl : UISegmentedControl
    {
        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            // Getting touch information to work out whether segment has been pressed, then dragged off to cancel the event
            // Comment these lines out if you don't care about handling this
            CGPoint locationPoint = ((UITouch)touches.AnyObject).LocationInView(this);
            CGPoint viewPoint = this.ConvertPointFromView(locationPoint, this);
            // Save the selected segment first
            nint current = this.SelectedSegment;
            // then fire the event
            base.TouchesEnded(touches, evt);
            // Check if the touch point is still on the control when the touch has ended, 
            // as well as comparing the current and new selected segment values 
            // and then fire the ValueChanged event if the same segment is pressed
            // Use this line and comment the second if statement if you don't care about handling click and drag to cancel the event 
            //if (current == this.SelectedSegment)
            if ((this.PointInside(viewPoint, evt)) && (current == this.SelectedSegment))
            {
                this.SelectedSegment = -1;
                SendActionForControlEvents(UIControlEvent.ValueChanged);
            }
        }
    }
 
