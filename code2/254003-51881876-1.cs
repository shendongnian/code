        private EditingState _PhysicianEditingState;
        public EditingState PhysicianEditingState
        {
            get { return _PhysicianEditingState; }
            set
            {
                _PhysicianEditingState = value;
                PhysicianTypeTabAreLocked = (PhysicianEditingState != EditingState.NotEditing);
                NotifyPropertyChanged("PhysicianTypeTabAreLocked");
            }
        }
