    class StoryBoardManager : System.Windows.Media.Animation.Storyboard
    {
        public void ChangeRectangleAlignment(DependencyObject target, VerticalAlignment verticalAlignment, HorizontalAlignment horizontalAlignment, int BeginTimeMillisecond)
        {
            ObjectAnimationUsingKeyFrames objectAnimation = new ObjectAnimationUsingKeyFrames()
            {
                BeginTime = TimeSpan.FromMilliseconds(0)
            };
            Storyboard.SetTarget(objectAnimation, target);
            Storyboard.SetTargetProperty(objectAnimation, new PropertyPath("(FrameworkElement.HorizontalAlignment)"));
            DiscreteObjectKeyFrame keyFrame = new DiscreteObjectKeyFrame(horizontalAlignment, TimeSpan.FromMilliseconds(BeginTimeMillisecond));
            objectAnimation.KeyFrames.Add(keyFrame);
            this.Children.Add(objectAnimation);
        }
    }
