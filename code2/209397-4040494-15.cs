    public static class ClickMenuItemExtensions
    {
        public static EventHandler ToEventHandler(this ClickMenuItem clickMenuItem)
        {
            if (clickMenuItem == null)
                return null;
                
            // new EventHandler not required, included only for clarity 
            return new EventHandler(new Closure(clickMenuItem).Invoke);
        }
    
        private sealed class Closure
        {
            private readonly ClickMenuItem _clickMenuItem;
    
            public Closure(ClickMenuItem clickMenuItem)
            {
                _clickMenuItem = clickMenuItem;
            }
    
            public void Invoke(object sender, EventArgs e)
            {
                _clickMenuItem(sender, e);
            }
        }
    }
