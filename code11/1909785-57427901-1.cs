    double rotationAngle = 0;
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        //Rotate
        this.rotationAngle += 90;
        this.grid1.RenderTransformOrigin = new Point(0.5, 0.5);
        rt.Angle = this.rotationAngle;
    }
    bool mIsHorizontalImageflipped = false;
    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        //Transform
        int[] value;
        float[] origin = new float[] { 0.5f, 0.5f };
        string path = "RenderTransform.Children[1].ScaleX";
        if (!this.mIsHorizontalImageflipped)
        {
            value = new int[] { 1, -1 };
            this.mIsHorizontalImageflipped = true;
        }
        else
        {
            this.mIsHorizontalImageflipped = false;
            value = new int[] { -1, 1 };
        }
        this.Animate(value, origin, path);
    }
    internal void Animate(int[] value, float[] origin, string path)
    {
        Storyboard sb = new Storyboard();
        this.grid1.RenderTransformOrigin = new Point(origin[0], origin[1]);
        DoubleAnimationUsingKeyFrames keyFrames = new DoubleAnimationUsingKeyFrames();
        SplineDoubleKeyFrame keyFrame = new SplineDoubleKeyFrame();
        keyFrame.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0));
        keyFrame.Value = value[0];
        keyFrames.KeyFrames.Add(keyFrame);
        keyFrame = new SplineDoubleKeyFrame();
        keyFrame.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1));
        KeySpline keySpline = new KeySpline();
        keySpline.ControlPoint1 = new Point(0.64, 0.84);
        keySpline.ControlPoint2 = new Point(0, 1);
        keyFrame.KeySpline = keySpline;
        keyFrames.KeyFrames.Add(keyFrame);
        keyFrame.Value = value[1];
        Storyboard.SetTargetProperty(keyFrames, new PropertyPath(path));
        Storyboard.SetTarget(keyFrames, this.grid1);
        sb.Children.Add(keyFrames);
        sb.Begin();
    }
