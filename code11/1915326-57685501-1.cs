     public class DialogFragment2: DialogFragment
    {
           Context context;  
        public DialogFragment2(Context context)
        {
            this.context = context;
        }
       
        public override Dialog OnCreateDialog(Bundle savedInstanceState)
            {
             LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
             var view = inflater.Inflate(Resource.Layout.user_registered, null, false);
            Button btnOK = view.FindViewById<Button>(Resource.Id.btnOkay);
            btnOK.Click += BtnOK_Click;
            AlertDialog.Builder alert = new AlertDialog.Builder(Activity);
                alert.SetTitle("Custom Dialog");
                alert.SetView(view);
                alert.SetCancelable(false);
                
                //alert.SetPositiveButton("OK", (senderAlert, args) => {
                //    Toast.MakeText(Activity, "Go!", ToastLength.Short).Show();
                //});
                //alert.SetNegativeButton("Cancel", (senderAlert, args) => {
                //    Toast.MakeText(Activity, "Cancelled!", ToastLength.Short).Show();
                //});
                AlertDialog alertDialog = alert.Create();
                alertDialog.SetCanceledOnTouchOutside(false);
               return alertDialog;
            }
        private void BtnOK_Click(object sender, EventArgs e)
        {
                var intent = new Intent(Activity, typeof(MainActivity));
                StartActivity(intent);
        }    
    }
