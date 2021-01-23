            placeholder = lsbplanes.SelectedIndex;
            int idx = placeholder;
            while (idx < lsbplanes.Items.Count)
            {
                newplane.PlanePosition.Counter = idx+1;
                placex = newplane.PlanePostion.X;
                placey = newplane.PlanePostion.Y;
                placespeed = newplane.Getspeed();
                placedic = newplane.Getdirection();
                newplane.PlanePostion.Counter = idx;
                newplane.PlanePostion.X = placex;
                newplane.PlanePostion.Y = placey;
                newplane.PlanePostion.Speed = placespeed;
                newplane.PlanePostion.Direction = placedic;
                idx++;
            }
            // Need to zero out elements at the end
            newplant.PlanePosition.Counter = lsbplanes.Items.Count;
            /* Zeroing code goes here */
            newplane.PlanePosition.Counter = placeholder;
            lsbplanes.Items.RemoveAt(lsbplanes.SelectedIndex);
