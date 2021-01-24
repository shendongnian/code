private void MouseMoveMethod(object sender, MouseEventArgs e)
        {
            var obj = sender as Line;
             
            obj.X1 = e.GetPosition(this).X; //Line start x coordinate
            obj.Y1 = e.GetPosition(this).Y; //Line start y coordinate
            ...
        }
Try to give more explanation to your question next time. 
