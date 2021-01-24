      List<Progression> progressions;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
           
            View view = inflater.Inflate(Resource.Layout.layout1, container, false);
            ListView listView1 = view.FindViewById<ListView>(Resource.Id.listView1);
            progressions = new List<Progression>();
            
            progressions.Add(new Progression() { ProgressionIDs="1" , ProgressionNames= "Vegetables" });
            progressions.Add(new Progression() { ProgressionIDs = "2", ProgressionNames = "Fruits" });
            progressions.Add(new Progression() { ProgressionIDs = "3", ProgressionNames = "Flower Buds" });
            progressions.Add(new Progression() { ProgressionIDs = "4", ProgressionNames = "Legumes" });
            progressions.Add(new Progression() { ProgressionIDs = "5", ProgressionNames = "Bulbs" });
           progressions.Add(new Progression() { ProgressionIDs = "6", ProgressionNames = "Tubers" });
            var myAdapter=new MyAdapter(this.Activity, progressions);
            listView1.Adapter = myAdapter;
       
            listView1.ItemClick += ListView1_ItemClick;
            return view;
          
        }
        private void ListView1_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var myPostion= e.Position;
            Progression progression = progressions[myPostion];
            Toast.MakeText(this.Activity,progression.ProgressionIDs+" "+progression.ProgressionNames,ToastLength.Short).Show();
        
        }
