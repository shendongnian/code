    protected override void OnCreate(Bundle bundle)
    {
        Android.Net.Uri uri = Intent.Data;
        if (uri != null)
        {
            App.Firstname = uri.GetQueryParameter("firstname");
            App.Lastname = uri.GetQueryParameter("lastname");
        }
    }
