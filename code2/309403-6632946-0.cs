    myListBox.BeginInvoke(new MyDelegate(DelegateMethod), "hi there");
    
    public void DelegateMethod(ListView myControl, string message)
    {
       myControl.Items.Add (message);
    }
