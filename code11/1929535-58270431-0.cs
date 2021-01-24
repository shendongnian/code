    public void Execute(object parameter)
    {
        PasswordBox pb = parameter as PasswordBox;
        System.Windows.MessageBox.Show(pb.Password);
        //...
    }
