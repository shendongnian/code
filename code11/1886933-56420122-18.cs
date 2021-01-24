    private Role role;
    public Role Role
        {
            get => role;
            set
            {
                role = value;
                NotifyPropertyChanged("Role");
            }
        }
