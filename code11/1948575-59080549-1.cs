     protected override void OnNewIntent(Intent intent)
     {
       Android.Net.Uri uri  = Intent.Data;
       if(uri != null)
       {
          string firstName = uri.GetQueryParameter("firstname");
          string lastName = uri.GetQueryParameter("lastname");
       }
       base.OnNewIntent(intent);
     }
    
