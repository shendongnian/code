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
    private void Box_SizeChanged(object sender, EventArgs e)
        {
            //you could get the box's location here
            Console.WriteLine($"Box coordinates:{box.X} {box.Y} {box.Width} {box.Height}");
        }
    
