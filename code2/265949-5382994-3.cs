    private void Model_HandleLazyLoadData(object sender, LazyLoadEventArgs e)
    {
        switch (e.PropertyName)
        {
            case "PhoneNumbers":
                e.Data = DAL.LoadPhoneNumbers(e.Key);
                break;
            ...
        }
    }
