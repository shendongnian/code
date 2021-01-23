    class MyViewModel : AsyncBindableBase
    {
        public string Title
        {
            get
            {
                return Property.Get(GetTitleAsync);
            }
        }
        private async Task<string> GetTitleAsync()
        {
            //...
        }
    }
