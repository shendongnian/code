    [MarkupExtensionReturnType(typeof(object))]
    public class DelayedBindingExtension : MarkupExtension
    {
        private readonly Binding _binding = new Binding();
        public DelayedBindingExtension()
        {
            //Default value for delay
            Delay = TimeSpan.FromSeconds(0.5);
        }
        public DelayedBindingExtension(PropertyPath path)
            : this()
        {
            Path = path;
        }
        #region properties
        [DefaultValue(null)]
        public object AsyncState
        {
            get { return _binding.AsyncState; }
            set { _binding.AsyncState = value; }
        }
        [DefaultValue(false)]
        public bool BindsDirectlyToSource
        {
            get { return _binding.BindsDirectlyToSource; }
            set { _binding.BindsDirectlyToSource = value; }
        }
        [DefaultValue(null)]
        public IValueConverter Converter
        {
            get { return _binding.Converter; }
            set { _binding.Converter = value; }
        }
        [TypeConverter(typeof(CultureInfoIetfLanguageTagConverter)), DefaultValue(null)]
        public CultureInfo ConverterCulture
        {
            get { return _binding.ConverterCulture; }
            set { _binding.ConverterCulture = value; }
        }
        [DefaultValue(null)]
        public object ConverterParameter
        {
            get { return _binding.ConverterParameter; }
            set { _binding.ConverterParameter = value; }
        }
        [DefaultValue(null)]
        public string ElementName
        {
            get { return _binding.ElementName; }
            set { _binding.ElementName = value; }
        }
        [DefaultValue(null)]
        public object FallbackValue
        {
            get { return _binding.FallbackValue; }
            set { _binding.FallbackValue = value; }
        }
        [DefaultValue(false)]
        public bool IsAsync
        {
            get { return _binding.IsAsync; }
            set { _binding.IsAsync = value; }
        }
        [DefaultValue(BindingMode.Default)]
        public BindingMode Mode
        {
            get { return _binding.Mode; }
            set { _binding.Mode = value; }
        }
        [DefaultValue(false)]
        public bool NotifyOnSourceUpdated
        {
            get { return _binding.NotifyOnSourceUpdated; }
            set { _binding.NotifyOnSourceUpdated = value; }
        }
        [DefaultValue(false)]
        public bool NotifyOnTargetUpdated
        {
            get { return _binding.NotifyOnTargetUpdated; }
            set { _binding.NotifyOnTargetUpdated = value; }
        }
        [DefaultValue(false)]
        public bool NotifyOnValidationError
        {
            get { return _binding.NotifyOnValidationError; }
            set { _binding.NotifyOnValidationError = value; }
        }
        [DefaultValue(null)]
        public PropertyPath Path
        {
            get { return _binding.Path; }
            set { _binding.Path = value; }
        }
        [DefaultValue(null)]
        public RelativeSource RelativeSource
        {
            get { return _binding.RelativeSource; }
            set { _binding.RelativeSource = value; }
        }
        [DefaultValue(null)]
        public object Source
        {
            get { return _binding.Source; }
            set { _binding.Source = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UpdateSourceExceptionFilterCallback UpdateSourceExceptionFilter
        {
            get { return _binding.UpdateSourceExceptionFilter; }
            set { _binding.UpdateSourceExceptionFilter = value; }
        }
        [DefaultValue(UpdateSourceTrigger.Default)]
        public UpdateSourceTrigger UpdateSourceTrigger
        {
            get { return _binding.UpdateSourceTrigger; }
            set { _binding.UpdateSourceTrigger = value; }
        }
        [DefaultValue(null)]
        public object TargetNullValue
        {
            get { return _binding.TargetNullValue; }
            set { _binding.TargetNullValue = value; }
        }
        [DefaultValue(null)]
        public string StringFormat
        {
            get { return _binding.StringFormat; }
            set { _binding.StringFormat = value; }
        }
        [DefaultValue(false)]
        public bool ValidatesOnDataErrors
        {
            get { return _binding.ValidatesOnDataErrors; }
            set { _binding.ValidatesOnDataErrors = value; }
        }
        [DefaultValue(false)]
        public bool ValidatesOnExceptions
        {
            get { return _binding.ValidatesOnExceptions; }
            set { _binding.ValidatesOnExceptions = value; }
        }
        [DefaultValue(null)]
        public string XPath
        {
            get { return _binding.XPath; }
            set { _binding.XPath = value; }
        }
        [DefaultValue(null)]
        public Collection<ValidationRule> ValidationRules
        {
            get { return _binding.ValidationRules; }
        }
        #endregion
        [DefaultValue(null)]
        public TimeSpan Delay { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            try
            {
                _binding.Mode = BindingMode.TwoWay;
                _binding.UpdateSourceTrigger = UpdateSourceTrigger.Explicit;
            }
            catch (InvalidOperationException)  //Binding in use already don't change it
            {
            }
            var valueProvider = serviceProvider.GetService(typeof (IProvideValueTarget)) as IProvideValueTarget;
            if (valueProvider != null)
            {
                var bindingTarget = valueProvider.TargetObject as DependencyObject;
                var bindingProperty = valueProvider.TargetProperty as DependencyProperty;
                if (bindingProperty != null && bindingTarget != null)
                {
                    var result = (BindingExpression)_binding.ProvideValue(serviceProvider);
                    new DelayBindingManager(result, bindingTarget, bindingProperty, Delay);
                    return result;
                }
            }
            return this;
        }
        private class DelayBindingManager
        {
            private readonly BindingExpressionBase _bindingExpression;
            private readonly DependencyProperty _bindingTargetProperty;
            private DependencyPropertyDescriptor _descriptor;
            private readonly DispatcherTimer _timer;
            public DelayBindingManager(BindingExpressionBase bindingExpression, DependencyObject bindingTarget, DependencyProperty bindingTargetProperty, TimeSpan delay)
            {
                _bindingExpression = bindingExpression;
                _bindingTargetProperty = bindingTargetProperty;
                _descriptor = DependencyPropertyDescriptor.FromProperty(_bindingTargetProperty, bindingTarget.GetType());
                if (_descriptor != null)
                    _descriptor.AddValueChanged(bindingTarget, BindingTargetTargetPropertyChanged);
                _timer = new DispatcherTimer();
                _timer.Tick += TimerTick;
                _timer.Interval = delay;
            }
            private void BindingTargetTargetPropertyChanged(object sender, EventArgs e)
            {
                var source = (DependencyObject)sender;
                if (!BindingOperations.IsDataBound(source, _bindingTargetProperty))
                {
                    if (_descriptor != null)
                    {
                        _descriptor.RemoveValueChanged(source, BindingTargetTargetPropertyChanged);
                        _descriptor = null;
                    }
                    return;
                }
                _timer.Stop();
                _timer.Start();
            }
            private void TimerTick(object sender, EventArgs e)
            {
                _timer.Stop();
                _bindingExpression.UpdateSource();
            }
        }
    }
