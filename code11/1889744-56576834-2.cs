    private void BtnTemporary_Clicked(object sender, EventArgs e)
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    var Person = (Person)BindingContext;
                    lblTemp.Text=DependencyService.Get<IPersonalia>().getOwnNr();
                }
            }
