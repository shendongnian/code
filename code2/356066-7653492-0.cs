    public class MainChat : Activity
    {
        private EditText text2;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
    
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
    
            // Get our button from the layout resource,
            // and attach an event to it
             text2 = FindViewById<EditText>(Resource.Id.text2);
         }
    
       private void  recieved()
       {
        text2.Text = "mesage";   // The text2 does not existe in this context 
    
        }
     }
