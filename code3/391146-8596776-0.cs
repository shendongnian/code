        class MyTouchDevice : TouchDevice {
            // lorepirri: use this to simulate a TouchPoint 
            public MyTouchDevice(int id_, Point pos_) : base(id_) { Position = pos_;  }
            public override TouchPoint GetTouchPoint(IInputElement relativeTo)
            {
                
                Point pt = Position;
                if (relativeTo != null)
                {
                   
                   // pt = this.ActiveSource.RootVisual.
                   //      TransformToDescendant((Visual)relativeTo).
                   //      Transform(Position);
                }
                var rect = new Rect(pt, new Size(1.0, 1.0));
                return new TouchPoint(this, pt, rect, TouchAction.Move);
                
                //throw new NotImplementedException();
            }
            public override TouchPointCollection GetIntermediateTouchPoints(IInputElement relativeTo)
            {
                throw new NotImplementedException();
            }
            public Point Position;
        };
