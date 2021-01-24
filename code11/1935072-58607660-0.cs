            Rectangle rect;
            Display display;
            foreach (PathInfo pi in PathInfo.GetActivePaths())
            {
                if (!pi.TargetsInfo[0].DisplayTarget.IsAvailable) continue;
                rect=System.Windows.Forms.Screen.GetWorkingArea(new Rectangle(pi.Position, pi.Resolution));
                display = new DisplayImpl()
                {
                    _name = string.IsNullOrEmpty(pi.TargetsInfo[0].DisplayTarget.FriendlyName)? "Generic PnP Monitor" : pi.TargetsInfo[0].DisplayTarget.FriendlyName,
                    _deviceId = pi.DisplaySource.DisplayName,
                    _devicePath=pi.TargetsInfo[0].DisplayTarget.DevicePath,
                    _bounds = new Rectangle(pi.Position,pi.Resolution),
                    _workingArea = rect,
                };
                list.Add(display);
            }
It produces the correct monitor name and settings pair! 
