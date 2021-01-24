     private Button button1;
        ObservableCollection<Person> list;
        private ListView listview;
        private void Button1_Click(object sender, EventArgs e)
        {
            list = new ObservableCollection<Person>();
           for(int i=0;i<20;i++)
            {
                Person p = new Person()
                {
                    Name = "cherry" + i,
                    Age = 20 + i
                };
                list.Add(p);
            }
            listview = FindViewById<ListView>(Resource.Id.listView1);
            var adapter = new Customadapter(this,list);
            listview.Adapter = adapter;
        }
