    using Android.App;
    using Android.OS;
    using Android.Runtime;
    using Android.Speech.Tts;
    
    namespace XamdroidMaster.Activities {
    
        [Activity(ParentActivity = typeof(MainActivity), Label = "Text to Speech")]
        public class TextToSpeechActivity : Activity, TextToSpeech.IOnInitListener {
    
            private TextToSpeech tts;
    
            protected override void OnCreate(Bundle savedInstanceState) {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.TextToSpeech);
    
                // Create text to speech object (first parameter: context; second parameter: object implementing TextToSpeech.IOnInitListener)
                // Note that it may take a few moments for the TTS engine to initialize (OnInit() will fire when it's ready)
                tts = new TextToSpeech(this, this, "com.google.android.tts");            
            }
    
            public void OnInit([GeneratedEnum] OperationResult status) {
                if (status == OperationResult.Success) {
                    tts.SetPitch(1f);
                    tts.SetSpeechRate(1f);
                    tts.Speak("Hello Luke!", QueueMode.Flush, null);
                }
            }
            
        }
    }
