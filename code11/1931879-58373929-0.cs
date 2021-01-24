     AlertDialog.Builder dialog = new AlertDialog.Builder(this);
            AlertDialog alert = dialog.Create();
            alert.SetTitle("Login Information");
            //alert.SetMessage("Complex Alert");
            //alert.SetIcon(Resource.Drawable.alert);
            LayoutInflater inflater = (LayoutInflater)this.GetSystemService(Context.LayoutInflaterService);
            View view = inflater.Inflate(Resource.Layout.input_layout, null);
            alert.SetView(view);
            EditText editText_name = view.FindViewById<EditText>(Resource.Id.et_name);
            EditText editText_pwd = view.FindViewById<EditText>(Resource.Id.et_pwd);
            Button button1 = view.FindViewById<Button>(Resource.Id.button1);
            Button button2 = view.FindViewById<Button>(Resource.Id.button2);
            button1.Click += delegate {
                Toast.MakeText(this,"press button1!",ToastLength.Short).Show();
            };
            button2.Click += delegate {
                Toast.MakeText(this, "press button2!", ToastLength.Short).Show();
            };
            //alert.SetButton("OK", (c, ev) =>
            //{
            //    // Ok button click task  
            //    string name = editText_name.Text;
            //    string password = editText_pwd.Text;
            //    Toast.MakeText(this, "name = " + name + " password= " + password, ToastLength.Long).Show();
            //});
            //alert.SetButton2("CANCEL", (c, ev) => { });
            alert.Show();
