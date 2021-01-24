        public string SelectedId
        {
            get { return selectedId; }
            set
            {
                selectedId = value;
                OrgElementViewModel orgElementViewModel = FindById(selectedId);
                if (orgElementViewModel != null) this.Selected = orgElementViewModel;
                OnPropertyChanged("SelectedId");
            }
        }
