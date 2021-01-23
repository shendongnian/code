    public class ValidationProperties
    {
         #region IsValid Dependency Property
        /// <summary>
        /// An attached dependency property which provides an
        /// </summary>
        public static readonly DependencyProperty IsValidProperty;
        /// <summary>
        /// Gets the <see cref="IsValidProperty"/> for a given
        /// <see cref="DependencyObject"/>, which provides an
        /// </summary>
        public static bool GetIsValid(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsValidProperty);
        }
        /// <summary>
        /// Sets the attached <see cref="IsValidProperty"/> for a given
        /// <see cref="DependencyObject"/>, which provides an
        /// </summary>
        public static void SetIsValid(DependencyObject obj, bool value)
        {
            obj.SetValue(IsValidProperty, value);
        }
         #endregion IsValid Dependency Property
        static ValidationProperties()
        {
            // Register attached dependency property
            IsValidProperty = DependencyProperty.RegisterAttached("IsValid",
                                                                typeof(bool),
                                                                typeof(ValidationProperties), 
                                                                new FrameworkPropertyMetadata(true));
        }
    }
