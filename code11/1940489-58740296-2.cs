    public void UpdateCustomer()
    {
        WindowManager wm = new WindowManager();
        CustomerUpdateViewModel cn = new CustomerUpdateViewModel(_events);
        wm.ShowWindow(cn);
    }
