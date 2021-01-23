            var pi = typeof(MainMenu).GetField("form", BindingFlags.NonPublic | BindingFlags.Instance);
            object form = pi.GetValue(this.Menu);
            pi.SetValue(this.Menu, null); 
            // etc..
            pi.SetValue(this.Menu, form);
