        public static void OpenContactPicker(Action<ImportedContact> callback)
        {
            _callback = callback;
            Intent intent = new Intent(Intent.ActionPick, ContactsContract.Contacts.ContentUri);
            CurrentActivity.StartActivityForResult(intent, RequestCodes.ContactPicker);
        }
