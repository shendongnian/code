        public bool HasTouchInput()
        {
            foreach (TabletDevice tabletDevice in Tablet.TabletDevices)
            {
                //Only detect if it is a touch Screen not how many touches (i.e. Single touch or Multi-touch)
                if(tabletDevice.Type == TabletDeviceType.Touch)
                    return true;
            }
            return false;
        }
    
