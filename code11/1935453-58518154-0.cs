    public class MyViewUICollectionViewCell2 : UICollectionViewCell
    {
        public const string ReuseIdentifier = "MyViewUICollectionViewCell2";
        public UILabel Label { get; }
        [Export("initWithFrame:")]
        public MyViewUICollectionViewCell2(CGRect frame) : base(frame)
        {
            var container = new UIView
            {
                BackgroundColor = UIColor.White,
                TranslatesAutoresizingMaskIntoConstraints = false
            };
            container.Layer.CornerRadius = 5;
            ContentView.AddSubview(container);
            container.TopAnchor.ConstraintEqualTo(ContentView.TopAnchor).Active = true;
            container.LeftAnchor.ConstraintEqualTo(ContentView.LeftAnchor).Active = true;
            container.BottomAnchor.ConstraintEqualTo(ContentView.BottomAnchor).Active = true;
            container.RightAnchor.ConstraintEqualTo(ContentView.RightAnchor).Active = true;
            Label = new UILabel
            {
                Lines = 0;
                TranslatesAutoresizingMaskIntoConstraints = false
            };
            container.AddSubview(Label);
            Label.TopAnchor.ConstraintEqualTo(container.TopAnchor).Active = true;
            Label.LeftAnchor.ConstraintEqualTo(container.LeftAnchor).Active = true;
            Label.BottomAnchor.ConstraintEqualTo(container.BottomAnchor).Active = true;
            Label.RightAnchor.ConstraintEqualTo(container.RightAnchor).Active = true;
            //Label.CenterXAnchor.ConstraintEqualTo(container.CenterXAnchor).Active = true;
            //CenterYAnchor.ConstraintEqualTo(container.CenterYAnchor).Active = true;
            //Label.WidthAnchor.ConstraintEqualTo(20).Active = true;
            //Label.HeightAnchor.ConstraintEqualTo(20).Active = true;
        }
    }
