        myToy = new MyToy();       
        var transform = new RotateTransform();
        transform.Name = "MyToy1Transform";
        myToy.RenderTransform = transform;
        this.RegisterName(transform.Name, transform);
       ...
        Storyboard story = new Storyboard();
        story.Children.Add(ani);
        Storyboard.SetTargetName(ani, transform.Name);
        Storyboard.SetTargetProperty(ani, new PropertyPath(RotateTransform.AngleProperty));
