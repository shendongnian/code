    private async Task saveDataAsync() {
            if (App.Current.Properties.ContainsKey("UserIsConnected"))
            {
                //Do something awesome.
                bool UserIsConnected = ((bool)App.Current.Properties["UserIsConnected"]);
                string name = ((string)App.Current.Properties["userName"]);
                System.Diagnostics.Debug.WriteLine("UserIsConnected= " + UserIsConnected +" name =" + name);
            }
            else {
                var app = App.Current;
                app.Properties["UserIsConnected"] = true;
                app.Properties["userName"] = "eric";
                await app.SavePropertiesAsync();
            }
        }
