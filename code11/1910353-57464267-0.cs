    public class StatefulObject : Prism.Mvvm.BindableBase
    {
        private bool _isDirty;
        public bool IsDirty
        {
            get => _isDirty;
            private set => SetProperty(ref _isDirty, value);
        }
        protected override bool SetProperty<T>(ref T storage, T value, Action onChanged, [CallerMemberName] string propertyName = null)
        {
            var isDirty = base.SetProperty(ref storage, value, onChanged, propertyName);
            if(isDirty && propertyName != nameof(isDirty))
            {
                IsDirty = true;
            }
            return isDirty;
        }
        public void Reset() => IsDirty = false;
    }
