         protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            lstViewData = FindViewById<ListView>(Resource.Id.listView);
             edtidLogin = FindViewById<EditText>(Resource.Id.edtidLogin); 
            var btnChange = FindViewById<Button>(Resource.Id.btnChange);
            listSource.Add(new Meeting() { idContact=1, idLogin=1, Place="test1" });
            listSource.Add(new Meeting() { idContact = 2, idLogin = 1, Place = "test2" });
            listSource.Add(new Meeting() { idContact = 3, idLogin = 1, Place = "test3" });
            listSource.Add(new Meeting() { idContact = 4, idLogin = 1, Place = "test4" });
            listSource.Add(new Meeting() { idContact = 5, idLogin = 1, Place = "test5" });
            listSource.Add(new Meeting() { idContact = 6, idLogin = 1, Place = "test6" });
            listSource.Add(new Meeting() { idContact = 7, idLogin = 1, Place = "test7" });
            listSource.Add(new Meeting() { idContact = 8, idLogin = 1, Place = "test8" });
            listSource.Add(new Meeting() { idContact = 9, idLogin = 1, Place = "test9" });
            listSource.Add(new Meeting() { idContact = 10, idLogin = 1, Place = "test10" });
            listSource.Add(new Meeting() { idContact = 11, idLogin = 1, Place = "test11" });
            listSource.Add(new Meeting() { idContact = 12, idLogin = 1, Place = "test12" });
            listSource.Add(new Meeting() { idContact = 13, idLogin = 1, Place = "test13" });
            listSource.Add(new Meeting() { idContact = 14, idLogin = 1, Place = "test14" });
            listSource.Add(new Meeting() { idContact = 15, idLogin = 1, Place = "test15" });
            listSource.Add(new Meeting() { idContact = 16, idLogin = 1, Place = "test16" });
  
            adapter = new ListViewAdapter(this, listSource);
            lstViewData.Adapter = adapter;
            btnChange.Click += BtnAdd_Click;
           
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            adapter.setSelectedId(Int32.Parse(edtidLogin.Text));
            adapter.NotifyDataSetChanged();
        }
       
     
