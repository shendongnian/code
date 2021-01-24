      <TextBlock x:Name="textBlock" Height="399" TextWrapping="Wrap" Text="Show/ Hide" VerticalAlignment="Top" Visibility="{Binding SetVisibility, Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}"/>
      public static readonly DependencyProperty SetVisibilityProperty =
         DependencyProperty.Register("SetVisibility", typeof(Visibility), typeof(Mainfreampage), new
            PropertyMetadata(Visibility.Visible, null));
        public Visibility SetVisibility
        {
            get { return (Visibility)GetValue(SetVisibilityProperty); }
            set { SetValue(SetVisibilityProperty, value); } 
        }
