    public static void OpenContactPicker(Action<ImportedContact> callback)
    {
        _callback = callback;
        Intent intent = new Intent(Intent.ActionPick);
        intent.SetType(ContactsContract.CommonDataKinds.Phone.ContentType);
        CurrentActivity.StartActivityForResult(intent, RequestCodes.ContactPicker);
    }
