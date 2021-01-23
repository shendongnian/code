        void HostControl_Loaded(object sender, RoutedEventArgs e)
        {
            _adorner = new RectangleAdorner(superMagic);
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(superMagic);
            layer.Add(_adorner);
        }
