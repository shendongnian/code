    public partial class ReviewsControl : UserControl
    {
        public static readonly DependencyProperty StatusDisplayProperty =
            DependencyProperty.Register(
                nameof(StatusDisplay), typeof(string), typeof(ReviewsControl);
        public string StatusDisplay
        {
            get { return (string)GetValue(StatusDisplayProperty); }
            set { SetValue(StatusDisplayProperty, value); }
        }
    }
