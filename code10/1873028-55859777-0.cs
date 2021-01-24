     public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            Toast.MakeText(this, "Activity", ToastLength.Short).Show();
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
