    public class MainActivity : AppCompatActivity
    {
        private static  TextView speechtext;
        private static  TextToSpeech saytext;       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.layout1);
            speechtext = FindViewById<TextView>(Resource.Id.textView1);
          
            saytext = new TextToSpeech(this, new MyListener(), "com.google.android.tts");
                            
        }
        class MyListener : Java.Lang.Object, TextToSpeech.IOnInitListener
        {
          
            public void OnInit([GeneratedEnum] OperationResult status)
            {
                if(status==OperationResult.Success)
                {
                    saytext.SetLanguage(Locale.Us);
                    saytext.SetPitch(1.5f);
                    saytext.SetSpeechRate(1.5f);
                    saytext.Speak(speechtext.Text, QueueMode.Flush, null, null);
                }
               
            }
        }
    }
