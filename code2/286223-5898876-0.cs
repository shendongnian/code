            enum DrawBoxState { Normal, DesignMode, DrawingBox }
        DrawBoxState _currentState = DrawBoxState.Normal;
        Point _startPoint;
        Point _endPoint;
        void OnToolbarButtonClicked(object sender, EventArgs e)
        {
            switch (_currentState)
            {
                case DrawBoxState.Normal:
                    _currentState = DrawBoxState.DesignMode;
                    break;
                default:
                    _currentState = DrawBoxState.Normal;
                    break;
            }
        }
        void OnMouseDown(object sender, MouseEventArgs e)
        {
            switch (_currentState)
            {
                case DrawBoxState.DesignMode:
                    {
                        _currentState = DrawBoxState.OnDrawingBox;
                        _startPoint = e.Location; // not sure if this is right
                    }
                    break;
            }
        }
        void OnMouseUp(object sender, MouseEventArgs e)
        {
            switch (_currentState)
            {
                case DrawBoxState.DrawingBox:
                    {
                        _currentState = DrawBoxState.Normal;
                        _endPoint = e.Location;
                    }
                    break;
            }
        }
