    static class MapExtensions
    {
        public static void callPinClicked(this Map m, Pin p)
        {
            var mi = m.GetType().GetMethod(SendPinClicked, System.Reflection.BindingFlags.NonPublic  | System.Reflection.BindingFlags.Instance );
            if (mi != null) {
                mi.Invoke (m, new object[] { p } );
            }
        }
    }
