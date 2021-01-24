    private void PropertyChangedFunc(object sender, PropertyChangedEventArgs e)
            {
                UtilitiesModel obj = sender as UtilitiesModel;
                if(obj==null)return;
    
                if (e.PropertyName == "IsChecked")
                {
                    iCount1 = obj.IsChecked ? iCount1 + 1 : iCount1 - 1;
    
                    if (iCount1 > 19) //Block checking
                    {
                        obj.IsChecked = false;
                    }
                }
            }
