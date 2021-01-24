Csharp
 RestAPI rest = new RestAPI("http://Yoursite/wp-json/wc/v3/", "Customer Key", "Customer Secret");
            WCObject wc = new WCObject(rest);
            int pageNum = 1;
            var isNull = false;
            List<Customer> oldlist;
           
            while (!isNull)
            {
                
                var page = pageNum.ToString();
                x = await wc.Customer.GetAll(new Dictionary<string, string>() {
                {
                    "page", page
                }, {
                    "per_page", "100"
                }
            });
                oldlist = FetchCustomers.customers ?? new List<Customer>();
                if (x.Count == 0) {
                   
                    break;
                }
                else
                {
                   
                    pageNum++;
                    
                    FetchCustomers.customers = oldlist.Union(x).ToList();
                }
            }
How i'm Validating 
Csharp
 var list = FetchCustomers.customers.ToList();
            foreach (var user in list)
            {
                if (user.username == Usernamelabel.Text)
                {
                    Application.Current.Properties["CId"] = user.id;
                    Application.Current.Properties["CEmail"] = user.email;
                    Application.Current.Properties["CUsername"] = user.username;
                    Users.Loggedin = true;
                    Application.Current.SavePropertiesAsync();
                    App.Current.MainPage.DisplayAlert("Empty Values", "Phase 2 Done your logged in ", "OK");
              
                }
            }
User is Validated From username I'm busy with another Process to Validate the user by The Wordpress API and getting a JWT token then Sending it to this Method to validate and Fetch the Customer and then Persisting the User.
