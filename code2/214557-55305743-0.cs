    private void OnMouseTilt(int tilt)
        {
            // Write your horizontal handling codes here.
            if(!mainScrollViewer.IsVisible) return;
            if (tilt > 0)
            {
                mainScrollViewer.LineLeft();
            }
            else
            {
                mainScrollViewer.LineRight();
            }
        }
