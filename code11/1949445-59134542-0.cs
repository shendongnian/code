    protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 0x001)
            {
                if (resultCode == Result.Ok)
                {
                    string result = data.GetStringExtra("test");
                    Toast.MakeText(this,"reslut is: " + result,ToastLength.Short).Show();
                }
                
            }
        }
