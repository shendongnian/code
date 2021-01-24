    public class CEntity : INotifyPropertyChanged
    {
        private readonly Entity _entity;
        public CEntity(Entity entity)
        {
            _entity = entity;
        }
        public int X
        {
            get => _entity.X;
            set
            {
                _entity.X = value;
                OnPropertyChanged();
            }
        }
        public int Y
        {
            get => _entity.Y;
            set
            {
                _entity.Y = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
