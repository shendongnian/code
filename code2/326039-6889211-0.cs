            Button btn = new Button();
            this.Controls.Add(btn);
            btn.Click += (o, x) =>
            {
                Button b = o as Button;
                FieldInfo eventclick = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
                object eventValue = eventclick.GetValue(b);
                PropertyInfo events = b.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
                EventHandlerList eventHandlerList = (EventHandlerList)events.GetValue(b, null);
                eventHandlerList .RemoveHandler(eventValue, eventHandlerList [eventValue]);
                MessageBox.Show("Test");
            };
