        private void loadLeft_Click(object sender, RoutedEventArgs e) {
            var leftUser = UsrLeft.Text;
            if(leftUser != "") {
                ItemCollection coll = getItemCollectionForUser(leftUser);
            }else {
                //Error Handling
            }
        }
        private ItemCollection getItemCollectionForUser(string user) {
           //return ItemCollection here
        }
