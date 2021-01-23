    ...
        private void ThisAddInStartup(object sender, EventArgs e)
        {
            this.Application.Session.Stores.StoreAdd += StoreAddEventHandler;
            this.Application.Session.Stores.BeforeStoreRemove += BeforeStoreRemove;
        }
        private void StoreAddEventHandler(Store store)
        {
            if (store.IsDataFileStore)
            {
              //Do something.
            }
        }
        private void BeforeStoreRemove(Store store, ref bool cancel)
        {
            if (store.IsDataFileStore)
            {
                //Do something.
            }
        }
...
