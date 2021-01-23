        for (int i = PushPinLayer.Children.Count; i >= 0 ; i--)
        {
            if (PushPinLayer.Children[i].GetType() == typeof(Pushpin))
            {
                PushPinLayer.Children.RemoveAt(i);
            }
        }
