    <Grid>
    <!--Set some height and width as you like-->
         <Canvas x:Name="CnvBarCodeImage" AllowDrop="True">
        
                                    </Canvas>
    <Grid>
    private void CreateUIShapes(int numberOfWindows)
            {
    //If you want multiple shapes put it inside a loop
                    Thumb th = null;
                    th = new Thumb();
                    th.Width = 200;
                    th.Height = 100;
                    th.Foreground = new SolidColorBrush(Windows.UI.Colors.Transparent);
                    th.BorderBrush = item.BorderColor;
                    th.BorderThickness = new Thickness(3);
                   
                    th.DragDelta += (sender, e) => Th_DragDelta(sender, e);
                    Canvas.SetLeft(th, 100);
                    Canvas.SetTop(th, 80);
                   CnvBarCodeImage.Children.Add(th);
                
            }
    
     private event Action<Thumb, double, double> ChangeDimensions;
     private void Th_DragDelta(object sender, DragDeltaEventArgs e, List<Dimensions> limitedWindowMovements)
            {
                var selectedDraggableThumb = sender as Thumb;
                double left = (Canvas.GetLeft(selectedDraggableThumb) >= 0) ? Canvas.GetLeft(selectedDraggableThumb) : 0;
                double top = (Canvas.GetTop(selectedDraggableThumb) >= 0) ? Canvas.GetTop(selectedDraggableThumb) : 0;
    
                if (ChkDualMode.IsChecked == true)
                {
                    var otherDraggableThumbs = CnvBarCodeImage.Children.OfType<Thumb>().Where(x => x != selectedDraggableThumb).ToList();
                    var maxTopSelected = 0
                   
                    var maxLeftSelected = 0;
                   
                    //There may be n number of windows.
                    foreach (var item in otherDraggableThumbs)
                    {
                        //TOP
                        //Canvas.GetTop(SelectedDraggableThumb) <= 0 || Canvas.GetTop(item) <= 0 original.
                        if (Canvas.GetTop(selectedDraggableThumb) <= maxTopSelected || Canvas.GetTop(item) <= maxTopSelected)
                        {
                            if (e.VerticalChange <= 0)
                            {
                                ChangeDimensions -= BarCodeServiceView_ChangeDimensions;
                                return;
                            }
                        }
    
                        //LEFT
                        //Canvas.GetLeft(SelectedDraggableThumb) <= 0 || Canvas.GetLeft(item) <= 0 original.
                        else if (Canvas.GetLeft(selectedDraggableThumb) <= maxLeftSelected || Canvas.GetLeft(item) <= maxLeftSelected)
                        {
                            if (e.HorizontalChange <= 0)
                            {
                                ChangeDimensions -= BarCodeServiceView_ChangeDimensions;
                                return;
                            }
                        }
    
                        //RIGHT
                        else if (Canvas.GetLeft(selectedDraggableThumb) >=
                            CnvBarCodeImage.ActualWidth - selectedDraggableThumb.ActualWidth ||
                            Canvas.GetLeft(item) >= CnvBarCodeImage.ActualWidth - item.ActualWidth)
                        //|| Canvas.GetLeft(SelectedDraggableThumb) >= maxRightSelected
                        //|| Canvas.GetLeft(item) >= maxRightSelected)
                        {
                            if (e.HorizontalChange > 0)
                            {
                                ChangeDimensions -= BarCodeServiceView_ChangeDimensions;
                                return;
                            }
                        }
    
    
                        //BOTTOM
                        else if (Canvas.GetTop(selectedDraggableThumb) + selectedDraggableThumb.ActualHeight >= CnvBarCodeImage.ActualHeight ||
                                Canvas.GetTop(item) + item.ActualHeight >= CnvBarCodeImage.ActualHeight)
                        {
                            if (e.VerticalChange >= 0)
                            {
                                ChangeDimensions -= BarCodeServiceView_ChangeDimensions;
                                return;
                            }
                        }
    
                        if (ChangeDimensions == null)
                        {
                            ChangeDimensions += BarCodeServiceView_ChangeDimensions;
                        }
    
                    }
    
                    foreach (var item in otherDraggableThumbs)
                    {
                        ChangeDimensions?.Invoke(item, e.HorizontalChange, e.VerticalChange);
                    }
    
                    left = (Canvas.GetLeft(selectedDraggableThumb) >= CnvBarCodeImage.ActualWidth) ? CnvBarCodeImage.ActualWidth : left;
                    top = (Canvas.GetTop(selectedDraggableThumb) >= CnvBarCodeImage.ActualHeight) ? CnvBarCodeImage.ActualHeight : top;
                    Canvas.SetLeft(selectedDraggableThumb, left + e.HorizontalChange);
                    Canvas.SetTop(selectedDraggableThumb, top + e.VerticalChange);
                }
                else
                {
                    //In single mode limit the movement as well.
                    int.TryParse(selectedDraggableThumb.Name, out var indexFromName);
                    var limitedDimensionForWindow = limitedWindowMovements[indexFromName];
    
                    var maxTop = limitedDimensionForWindow.MaxTopPossible == null ? 0 : limitedDimensionForWindow.MaxTopPossible;
                    var maxLeft = limitedDimensionForWindow.MaxLeftPossible == null ? 0 : limitedDimensionForWindow.MaxLeftPossible;
                    var maxRight = limitedDimensionForWindow.MaxRightPossible == null ? CnvBarCodeImage.ActualWidth - selectedDraggableThumb.ActualWidth : limitedDimensionForWindow.MaxRightPossible;
                    var maxBottom = limitedDimensionForWindow.MaxBottomPossible == null ? CnvBarCodeImage.ActualHeight - selectedDraggableThumb.ActualHeight : limitedDimensionForWindow.MaxBottomPossible;
    
                    if (Canvas.GetTop(selectedDraggableThumb) <= maxTop)
                    {
                        if (e.VerticalChange <= 0)
                        {
                            return;
                        }
                    }
                    else if (Canvas.GetLeft(selectedDraggableThumb) <= maxLeft)
                    {
                        if (e.HorizontalChange <= 0)
                        {
                            return;
                        }
                    }
                    else if (Canvas.GetLeft(selectedDraggableThumb) >= maxRight)
                    {
                        if (e.HorizontalChange >= 0)
                        {
                            return;
                        }
                    }
                    else if (Canvas.GetTop(selectedDraggableThumb) >= maxBottom)
                    {
                        if (e.VerticalChange >= 0)
                        {
                            return;
                        }
                    }
                    left = (Canvas.GetLeft(selectedDraggableThumb) >= CnvBarCodeImage.ActualWidth) ? CnvBarCodeImage.ActualWidth : left;
                    top = (Canvas.GetTop(selectedDraggableThumb) >= CnvBarCodeImage.ActualHeight) ? CnvBarCodeImage.ActualHeight : top;
                    Canvas.SetLeft(selectedDraggableThumb, left + e.HorizontalChange);
                    Canvas.SetTop(selectedDraggableThumb, top + e.VerticalChange);
                }
            }
    
            private void BarCodeServiceView_ChangeDimensions(Thumb sender, double arg1, double arg2)
            {
                if (sender != null)
                {
                    double left = (Canvas.GetLeft(sender) > 0) ? Canvas.GetLeft(sender) : 0;
                    double top = (Canvas.GetTop(sender) > 0) ? Canvas.GetTop(sender) : 0;
                    Canvas.SetLeft(sender, left + arg1);
                    Canvas.SetTop(sender, top + arg2);
                }
            }
