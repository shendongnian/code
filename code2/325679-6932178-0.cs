    class MyAnimationListener : Java.Lang.Object,
            Android.Views.Animations.Animation.IAnimationListener
    {
        Activity self;
        public MyAnimation (Activity self)
        {
            this.self = self;
        }
        public void OnAnimationEnd (Animation animation)
        {
            self.StartActivity (new Intent (self, typeof (QuizMenuActivity)));
            self.Finish ();
        }
        public void OnAnimationRepeat (Animation animation)
        {
        }
        public void OnAnimationStart (Animation animation)
        {
        }
    }
    // ...
    fade2.SetAnimationListener (new MyAnimationListener (this));
