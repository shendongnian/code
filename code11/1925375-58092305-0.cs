    public class Fragment1 : Fragment
    {
        private TextView tv;
        public string mString;
       
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
            mString = prefs.GetString("Data", " ");
            View v = inflater.Inflate(Resource.Layout.Fragment1,container,false);
            tv = v.FindViewById<TextView>(Resource.Id.textView1);
            tv.Text =mString;
            return v;
        }
    }
    public class MainActivity : AppCompatActivity
    {
        private Button btn1;
        private EditText edit;          
        private static Android.App.FragmentManager manager;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
           
            manager = FragmentManager;
            Fragment1 fragment = new Fragment1();
            manager.BeginTransaction().Add(Resource.Id.frameLayout1, fragment,"myfragmanetag").Commit();
            // t.Add(Resource.Id.fragment1,fragment);
            btn1 = FindViewById<Button>(Resource.Id.button1);
            edit= FindViewById<EditText>(Resource.Id.editText1);
            btn1.Click += delegate
              {
                  var text =edit.Text.ToString();
                  ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                  ISharedPreferencesEditor editor = prefs.Edit();              
                  editor.PutString("Data", text);
                  editor.Apply();
                  //editor.Commit();
                  Fragment frg = null;
                  frg = manager.FindFragmentByTag("myfragmanetag");
                  manager.BeginTransaction().Detach(frg).Attach(frg).Commit();
              };
        }
    }
