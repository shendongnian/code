        public static readonly DependencyProperty DescriptionProperty = 
           DependencyProperty.Register(
              "Description",
              typeof(string),
              typeof(WorkFlowPfazar),
              new PropertyMetadata(Description_Changed));
        public string Description
        {
            get
            {
                return (string)GetValue(DescriptionProperty);
            }
            set
            {
                SetValue(DescriptionProperty, value);
            }
        }
        private static void Description_Changed(DependencyObject Object, DependencyPropertyChangedEventArgs Args)
        {
            WorkFlowPfazar wf = Object as WorkFlowPfazar;
            if (wf == null)
                return;
            wf.tbDescription.Text = Args.NewValue.ToString();
        }
