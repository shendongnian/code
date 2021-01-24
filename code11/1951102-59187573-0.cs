    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }
        public UILabel labelOne { get; private set; }
        public UILabel labelTwo { get; private set; }
        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.
            labelOne = new UILabel();
            labelTwo = new UILabel();
            labelOne.Text = "test1";
            labelTwo.Text = "test2";
            labelOne.TextAlignment = UITextAlignment.Center;
            labelTwo.TextAlignment = UITextAlignment.Center;
            labelOne.BackgroundColor = UIColor.Red;
            labelTwo.BackgroundColor = UIColor.Blue;
            labelOne.TranslatesAutoresizingMaskIntoConstraints = false;
            labelTwo.TranslatesAutoresizingMaskIntoConstraints = false;
            View.Add(labelOne);
            View.Add(labelTwo);
            updateC();
        }
        public void updateC() {
            View.AddConstraints(new[] {
                NSLayoutConstraint.Create(labelOne, NSLayoutAttribute.Width, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1, 80),
                NSLayoutConstraint.Create(labelOne, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1, 80),
                NSLayoutConstraint.Create(labelOne, NSLayoutAttribute.Top , NSLayoutRelation.Equal, View, NSLayoutAttribute.Top, 1, 120),
                NSLayoutConstraint.Create(labelOne, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, View, NSLayoutAttribute.CenterX, 1, 0)
            });
            View.AddConstraints(new[] {
                NSLayoutConstraint.Create(labelTwo, NSLayoutAttribute.Width, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1, 80),
                NSLayoutConstraint.Create(labelTwo, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1, 80),
                NSLayoutConstraint.Create(labelTwo, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, labelOne, NSLayoutAttribute.CenterY, 1, 0),
                NSLayoutConstraint.Create(labelTwo, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1, -10)
            });
        }
    }
