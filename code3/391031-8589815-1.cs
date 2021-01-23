        public static readonly DependencyProperty ValidationErrorsProperty
            = DependencyProperty.RegisterAttached(
                "ValidationErrors",
                typeof(ObservableCollection<ValidationFailure>),
                typeof(ValidationErrorAttached),
                new FrameworkPropertyMetadata(new ObservableCollection<ValidationFailure>(), OnChangeCallBack));
        private static void OnChangeCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var list = (ObservableCollection<ValidationFailure>)e.NewValue;
            if (list != null)
            {
                list.CollectionChanged +=
                    delegate(
                        object sender,
                        System.Collections.Specialized.NotifyCollectionChangedEventArgs arg)
                        {
                            if (list.Count == 0)
                            {
                                ((TextBox) d).BorderBrush = null;
                            }
                            else
                            {
                                ((TextBox) d).BorderBrush = new SolidColorBrush(Colors.Red);
                            }
                        };
            }
        }
        public static void SetValidationErrors(DependencyObject element, ObservableCollection<ValidationFailure> value)
        {
            element.SetValue(ValidationErrorsProperty, value);
        }
        public static ObservableCollection<ValidationFailure> GetValidationErrors(DependencyObject element)
        {
            return (ObservableCollection<ValidationFailure>)element.GetValue(ValidationErrorsProperty);
        }
