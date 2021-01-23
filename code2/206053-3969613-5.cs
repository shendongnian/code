    public class HitControl {
        public Control ThisControl;
        private Rectangle ControlBounds;
        private Point Center;
        public HitControl (Control FormControl) {
            //  Note:  You don't need to consider control center points unless
            //  you plan to allow for controls placed over other controls... 
            //  Then you need to test the distance to the centers, as well, 
            //  and pick the shortest distance of to-edge, to-side, to-corner
             
            bool withinWidth = TestPoint.X > ControlBounds.X && TestPoint.X < ControlBounds.X + ControlBounds.Width;
            bool withinHeight = TestPoint.Y > ControlBounds.Y && TestPoint.Y < ControlBounds.Y + ControlBounds.Height;
            int EdgeLeftXDistance = Math.Abs(ControlBounds.Y - TestPoint.Y);
            int EdgeRightXDistance = Math.Abs(ControlBounds.Y + ControlBounds.Height - TestPoint.Y);
            
            int EdgeLeftYDistance = Math.Abs(ControlBounds.X - TestPoint.X);
            int EdgeRightYDistance = Math.Abs(ControlBounds.X + ControlBounds.Width - TestPoint.X);
            
            int EdgeXDistance = Math.Min(EdgeLeftXDistance, EdgeRightXDistance);
            int EdgeYDistance = Math.Min(EdgeLeftYDistance, EdgeRightYDistance);
            if (withinWidth && withinHeight) {
                return Math.Min(EdgeXDistance, EdgeYDistance);
            }
            if (withinWidth) {
                return EdgeYDistance;
            }
            
            if (withinHeight) {
                return EdgeXDistance;
            }
            
            return Math.Sqrt(EdgeXDistance ^ 2 + EdgeYDistance ^ 2);
            
        }
        public bool ContainsPoint (Point TestPoint) {
            return ControlBounds.Contains(TestPoint);
        }
    }
    //  Initialize and use this collection
    List<HitControl> hitControls = (from Control control in Controls
                                    select new HitControl(control)).ToList();
    Point testPoint = new Point(175, 619);
    double distance;
    double shortestDistance = 0;
    HitControl closestControl = null;
    
    foreach (HitControl hitControl in hitControls) {
        distance = hitControl.DistanceFrom(testPoint);
        if (shortestDistance == 0 || distance < shortestDistance) {
            shortestDistance = distance;
            closestControl = hitControl;
        }
    }
    if (closestControl != null) {
        Control foundControl = closestControl.ThisControl;
    }
