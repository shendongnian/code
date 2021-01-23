    foreach(var item in listBox8.Items) {
        Thread t = new Thread(new ParameterizedThreadStart(signinmobile));
        t.Start(item.ToString());
    }
    // Now that you started all thread to work on all items
    // You can cleanup the list box safely
    
    public void signinmobile(string parameter) {
        string yourString = parameter;
        //...
        if (accountstatus.Contains("Sign in information is not correct")) {
           listBox9.Items.Add(listBox8.SelectedItem.ToString() + "\r");
        } else  {
           listBox2.Items.Add(listBox8.SelectedItem.ToString() + "\r");
        }
    }
