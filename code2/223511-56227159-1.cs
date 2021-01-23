            private void PickGenLibrary_RaiseAllocLog(string orderNumber, string message, bool updateDB)
        {
            RaiseLog(orderNumber, message, false);
        }
        private void PickGenLibrary_RaiseAllocErrorLog(string orderNumber, string message, bool updateDB)
        {
            RaiseErrorLog(orderNumber, message, false);
        }
