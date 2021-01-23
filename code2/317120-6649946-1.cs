    public sealed class ViewModel : DependencyObject
    {
        #region Person
        /// <summary>
        /// The <see cref="DependencyProperty"/> for <see cref="Person"/>.
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                PersonPropertyName,
                typeof(Person),
                typeof(ViewModel),
                new UIPropertyMetadata(null));
    
        /// <summary>
        /// The name of the <see cref="Person"/> <see cref="DependencyProperty"/>.
        /// </summary>
        public const string PersonPropertyName = "Person";
    
        /// <summary>
        /// The Person
        /// </summary>
        public string Person
        {
            get { return (Person)GetValue(PersonProperty ); }
            set { SetValue(PersonProperty , value); }
        }
        #endregion      
    
        // snip
