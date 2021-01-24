     public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            Toast.MakeText(Activity, "Fragment", ToastLength.Short).Show();
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
