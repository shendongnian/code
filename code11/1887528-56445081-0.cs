C#
if (pageProvenienzaRichiesta.Frame != null)
            {
                pageProvenienzaRichiesta.Frame.Navigate(typeof(LoginPage));
            }
            else
            {
                Frame navigationFrame = Window.Current.Content as Frame;
                navigationFrame.Navigate(typeof(LoginPage));
            }
