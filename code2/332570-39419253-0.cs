    /// <summary>
    /// Base class for classes that need to implement <see cref="INotifyPropertyChanged"/>
    /// </summary>
    public class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Raised when a property value changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Updates a field for a named property
        /// </summary>
        /// <typeparam name="T">The type of the field</typeparam>
        /// <param name="field">The field itself, passed by-reference</param>
        /// <param name="newValue">The new value for the field</param>
        /// <param name="propertyName">The name of the associated property</param>
        protected void UpdatePropertyField<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                OnPropertyChanged(propertyName);
            }
        }
        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">The name of the property that has been changed</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.DynamicInvoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
