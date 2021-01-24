      var textView = FindViewById<TextView>(Resource.Id.textView);
            var checkToppingSugar = FindViewById<CheckBox>(Resource.Id.checkToppingSugar);
            checkToppingSugar.Click += (o, e) =>
            {
                if (checkToppingSugar.Checked)
                {
                    Toast.MakeText(this, "Selected", ToastLength.Short).Show();
                    textView.Text = "textView Topping Selected";
                }
                else
                {
                    Toast.MakeText(this, "Not selected", ToastLength.Short).Show();
                    textView.Text = "textView Topping Not selected";
                }
            };
