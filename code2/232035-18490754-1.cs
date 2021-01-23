    Image coolPic = new Image() { 
        Name="pic", 
        Source = new BitmapImage(new Uri("pack://application:,,,/images/cool.png")), 
        Stretch = Stretch.None // this preserves the original size, fill would fill
    };
    // register the new control
    RegisterName(coolPic.Name, coolPic);
    TextBlock text = new TextBlock() {
        Name = "myText",
        Text = "This is my cool Pic" 
    };
    // register the new control
    RegisterName(text.Name, text);
    myStack.Children.Add(coolPic);
    myStack.Children.Add(text);
