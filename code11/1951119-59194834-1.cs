c#
 int check;
            var btn = (YourButton)sender;
            var item = btn.BindingContext; //You can find other Properties of the said Item aswell
            check = Convert.ToInt32(item);
Here's How id do it on the Item selection instead of the button hope it helps
c#
 var obj = (YourCollection)e.SelectedItem;
            var ide = Convert.ToInt32(obj.PId); //Get the Item's Id or w.e els youd like to grab from the collection
//Below is a little Example of how i'm getting the current indexed items ID To use for later
            foreach (var item in z)
            {
                if (ide == item.PId)
                {
                    currentID = item.PId;
                   
                }
            }
