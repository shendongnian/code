        private void AnimatedButton_Clicked(System.Object sender, System.EventArgs e)
        {
            CreateAnimation();
        }
        private void CreateAnimation()
        {
            var animation = new Animation();
            animation.WithConcurrent(
               (f) => animatedButton.CornerRadius = (int)f, 0, 20, Easing.Linear, 0, 1);
            animation.WithConcurrent(
              (f) => animatedButton.WidthRequest = (int)f, 100, 40, Easing.Linear, 0, 1);
            animatedButton.Animate("CreateAnimation", animation, 16, 500, easing: Easing.Linear);
        }
