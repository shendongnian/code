        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            // throw new NotImplementedException();
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            //throw new NotImplementedException();
            Merchant = parameters.GetValue<Merchant>("merchant");
            Debug.WriteLine(Merchant.MerhcnatName);
        }
        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            // throw new NotImplementedException();
        }
