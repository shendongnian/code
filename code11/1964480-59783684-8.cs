    public class MainActivity : AppCompatActivity
    {
       
        private EditText edittext;
        List<person> items;
       private ListView mainList;
        private UsersListAdapter usersListAdapter;
        private person selecteditem;
        private List<person> searchUserList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            items = new List<person>()
            {
           new person(){username="cherry",age=12 },
           new person(){username="barry",age=23},
           new person(){username="wendy",age=13},
            new person(){username="wendy2",age=13},
             new person(){username="cherry3",age=12 },
           new person(){username="barry4",age=23}
            };
            //mainList = (ListView)FindViewById<ListView>(Resource.Id.mainlistview);
            //mainList.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, items);
         
            edittext = FindViewById<EditText>(Resource.Id.editText1);
            mainList = FindViewById<ListView>(Resource.Id.mainlistview);
            mainList.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e)
            {
                if(searchUserList.Count>0)
                {
                    selecteditem = searchUserList[e.Position];
                    int index = edittext.Text.LastIndexOf("@");
                    int count = edittext.Text.Length;
                    edittext.Text = edittext.Text.Remove(index+1,count-index-1).Insert(index+1,selecteditem.username.ToString());
                    //edittext.Text = edittext.Text + selecteditem.username.ToString();
                    edittext.SetSelection(edittext.Text.Length);
                    selecteditem = null;
                    mainList.Visibility = ViewStates.Gone;
                }
                
            };
            edittext.TextChanged += Edittext_TextChanged;                     
        }
        private void Edittext_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
          
            if (e.Text.ToString().Length > 2 && e.Text.ToString().Substring(e.Text.ToString().Length-2, 1) =="@")
            {
                Regex regex = new Regex("@([a-zA-Z])+");
                MatchCollection matches = regex.Matches(e.Text.ToString());
                if (matches != null && matches.Count != 0)
                {
                    int count = matches.Count;
                    for (int i = 0; i < count; i++)
                    {
                        string temptext = matches[i].ToString().Substring(1);
                         searchUserList = items.Where(s => s.username.ToLower().StartsWith(temptext.ToString().ToLower())).ToList();
                        
                        mainList.Adapter = new UsersListAdapter(this, searchUserList);
                        mainList.Visibility = ViewStates.Visible;
                    }
                }
                else
                {
                    mainList.Visibility = ViewStates.Gone;
                    mainList.Adapter = new UsersListAdapter(this, items);
                }
             
               
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
