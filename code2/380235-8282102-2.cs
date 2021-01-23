    for(int i = 0; i < listBox8.Items.Count; i++) {
        Thread t = new Thread(new ParameterizedThreadStart(signinmobile));
        t.Start(listBox8.Items[i].ToString());
    }
    // Now that you started all thread to work on all items
    // You can cleanup the list box safely
    
    public void signinmobile(string parameter) {
        string yourString = parameter; // No need to access the shared list
        //...
        if (accountstatus.Contains("Sign in information is not correct")) {
           listBox9.Items.Add(parameter + "\r");
           // No need to access the shared list to remove the item
        } else  {
           listBox2.Items.Add(parameter + "\r");
           // No need to access the shared list to remove the item
        }
    }
