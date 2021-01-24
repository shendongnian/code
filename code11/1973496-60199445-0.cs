    protected override void OnAppearing()
        {
            base.OnAppearing();
                box = new BoxView
                {
                    BackgroundColor = Color.Red,
                };
                AbsoluteLayout.SetLayoutBounds(box, new Rectangle(0.6, 0.6, 0.25, 0.25));
                AbsoluteLayout.SetLayoutFlags(box, AbsoluteLayoutFlags.All);
                absolutelayout.Children.Add(box);
                box.SizeChanged += Box_SizeChanged;
        }
     protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            //get the box's location
            Console.WriteLine($"Box coordinates:{box.X} {box.Y} {box.Width} {box.Height}");
        }
    
