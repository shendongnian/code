    public ObservableCollection<CustomerDto> CustomerCodeDtos
    {
        get 
        { 
           if(_customerCodes===null)
           {
              _customerCodes = _databaseService.GetAllCustomers();
           }
           return _customerCodes;
        }
    }  
