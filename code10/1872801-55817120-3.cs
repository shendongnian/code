        private void MyView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == Number1Property.PropertyName)
            {
                if (Number1 + 1 != Number2)
                    Number2 = Number1 + 1;
            }
            if (e.PropertyName == Number2Property.PropertyName)
            {
                if (Number1 + 1 != Number2)
                    Number1 = Number2 - 1;
            }
        }
