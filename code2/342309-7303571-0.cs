        public static Point GetLocationFromHandle(IntPtr handle, string controlNameToLocate) {
            Control c = FromHandle(handle);
            if (c != null)
            {
                Control myCtrl = c.Controls[controlNameToLocate] as Control;
                if (myCtrl != null)
                {
                    return myCtrl.Location;
                }
            }
            return Point.Empty;
        }
