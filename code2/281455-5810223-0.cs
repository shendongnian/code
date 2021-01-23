        ProgressBar _progressSec = new ProgressBar();
        DoubleAnimation newAnimation = new DoubleAnimation();
        Storyboard newStory = new Storyboard();
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _progressSec.Name = "_progressSec";
            _progressSec.Minimum = 0;
            _progressSec.Maximum = 59;
            _progressSec.Value = DateTime.Now.Second;
            this.RegisterName(_progressSec.Name, _progressSec);
            NewGrid.Children.Add(_progressSec);
            int from = DateTime.Now.Second;
            int to = 59;
            newAnimation.From = from;
            newAnimation.To = to;
            newAnimation.Duration = new Duration(TimeSpan.FromSeconds(to - from));
            newStory.Completed += new EventHandler(story_Completed);
            newStory.Children.Add(newAnimation);
            Storyboard.SetTarget(newAnimation, _progressSec);
            Storyboard.SetTargetProperty(newAnimation, new PropertyPath(ProgressBar.ValueProperty));
            newStory.Begin();
        }
        void story_Completed(object sender, EventArgs e)
        {
            int from2 = 0;
            int to2 = 59;
            newAnimation.From = from2;
            newAnimation.To = to2;
            newAnimation.Duration = new Duration(TimeSpan.FromMinutes(1));
            newStory.Children.Add(newAnimation);
            Storyboard.SetTarget(newAnimation, _progressSec);
            Storyboard.SetTargetProperty(newAnimation, new PropertyPath(ProgressBar.ValueProperty));
            newStory.Begin();
        }
