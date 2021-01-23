    public class MainChat : Activity
    {
        EditText text2; // <----- HERE
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            text2 = FindViewById<EditText>(Resource.Id.text2);
         }
    
       private void  recieved()
       {
        text2.Text = "mesage";   
    
        }
     }
