        void NodeDefinitionVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Location")
                NotifyPropertyChanged(() => TranslateMatrix);
        }
