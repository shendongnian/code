    private async void Image_PointerPressed(object sender, PointerRoutedEventArgs e)
        {            
            var image = sender as Image;
            var pointerPoint = e.GetCurrentPoint(sender as UIElement);
            var dropStatus = await image.StartDragAsync(pointerPoint);
        }
        private void Image_DragStarting(UIElement sender, DragStartingEventArgs args)
        {
            args.Data.Properties.Add("myKey", sender);
        }
