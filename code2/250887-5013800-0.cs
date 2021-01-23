    _service.GetCustomers(datetime, id, (customers, error) => {
       
                        if (error != null)
                        {                     
                            MessageBox.Show(error.Message);
                            return;
                        }
                        Customers = new ObservableCollection<CustomerViewModel>(customers);
                        IsBusy = false;
                   });
