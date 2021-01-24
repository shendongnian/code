    class CustomAdapter : BaseAdapter, View.IOnClickListener
    {
        private Dictionary<int, string> dictionary = new Dictionary<int, string>();
        List<string> items; //this is the data in my code ,you should replace your own data
        public CustomAdapter(List<string> value) // the parameter use your own data
        {
            //copy your data into the dictionary
            items = new List<string>();
            items = value;
            for (int i = 0; i < items.Count; i++)
            {
                dictionary.Add(i, items[i].ToString());
            }
        }
        public override Object GetItem(int position)
        {
            return items[position];
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_listview, null);
            view.FindViewById<TextView>(Resource.Id.txt_location).Text = item;
            var button1 = view.FindViewById<Button>(Resource.Id.btn_set);
            button1.Tag = position;
            button1.SetOnClickListener(this);
            return convertView;
        }
        public override int Count { get; }
        public void OnClick(View v)
        {
            //do the thing you want,location is your strLongitude 
            var location = dictionary[(int) v.Tag];
        }
    }
