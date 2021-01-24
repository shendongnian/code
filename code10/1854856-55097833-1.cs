      private void GanttChart_AxisViewChanged(object sender, ViewEventArgs e)
        {
            // LA VerticalLineAnnotation
            if (LA.Y > e.Axis.ScaleView.ViewMaximum || LA.Y < e.Axis.ScaleView.ViewMinimum)
            { RA.Visible = false; } 
            else
            {
                RA.Visible = true;
            } 
        }
    }
