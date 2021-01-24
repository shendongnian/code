     bool flag = true;
     button.LongClick += Button_LongClick;
     private void Button_LongClick(object sender, Android.Views.View.LongClickEventArgs e)
        {
            switch (flag)
        {
                case true:
                    // Toast error
                    Toast.MakeText(this,"the value of flag is true. " ,ToastLength.Short).Show();
                    break;
                case false:
                    // call a method
                    Toast.MakeText(this, "the value of flag is false. ", ToastLength.Short).Show();
                    break;
            }
        }
   
