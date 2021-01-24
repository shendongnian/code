     public void MakeQuickCall(string PhoneNumber)
        {
            try
            {
                if (ActivityCompat.CheckSelfPermission(MainActivity.macvivity, Android.Manifest.Permission.CallPhone) != Android.Content.PM.Permission.Granted)
                {
                    ActivityCompat.RequestPermissions(MainActivity.macvivity, new string[] { Android.Manifest.Permission.CallPhone }, 1);
                    return;
                }
                else
                {
                    var uri = Android.Net.Uri.Parse(string.Format("tel:{0}", PhoneNumber));
                    var intent = new Intent(Intent.ActionCall, uri);
                    Xamarin.Forms.Forms.Context.StartActivity(intent);
                    //MainActivity.macvivity.StartActivity(intent);
                }               
            }
            catch (Exception ex)
            {
                new AlertDialog.Builder(Android.App.Application.Context).SetPositiveButton("OK", (sender, args) =>
                {
                    //User pressed OK
                })
                .SetMessage(ex.ToString())
                .SetTitle("Android Exception")
                .Show();
            }
        }
