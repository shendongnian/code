    private RelayCommand btnclickcommmand;
        public RelayCommand MyBtnClickCommand
        {
            get { return btnclickcommmand; }
            set { btnclickcommmand = value; }
        }
     btnclickcommmand = new RelayCommand(() =>
            {
                //TODO            
                mytag = btnclickcommmand.BtnTag;
                System.Diagnostics.Debug.WriteLine(mytag+"Button create the flyout");
            });      
