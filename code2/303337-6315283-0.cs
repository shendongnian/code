    public static T Recreate<T>() where T : new()
    {    
        T _control = new T();    
        RadControlSetter.Dispatch(_control);    
        Logger.DebugFormat("Recreated control {0}", (_control as Control).ID);    
        return _control;
    }
     // defined somwhere in scope:    
    public static class RadControlSetter {
        public static void Dispatch<T>(T pRadControl) {
             Dispatch(pRadControl);
        }
        // add overload for each concrete type of Rad control
        private static void Dispatch(RadDockZone pRadControl) {
             var tSettings = new RadDockZoneSettings(...);
             // do RadDockZoneSettings specific stuff
        }
        private static void Dispatch(RadTab pRadControl) {
             var tSettings = new RadTabSettings(...);
             // do RadTabSettings specific stuff, etc...
        }
    }
