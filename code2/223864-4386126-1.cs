            List<UIElement> toRemove = new List<UIElement>();
            foreach (UIElement p in PushPinLayer.Children)
            {
                if(p.GetType() == typeof(Pushpin))
                {
                    toRemove.Add(p);
                }
            }
            foreach(UIElement p in toRemove)
            {
                PushPinLayer.Children.Remove(p);
            }
