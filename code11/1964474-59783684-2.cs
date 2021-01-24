    public class UsersListAdapter : BaseAdapter<person>
    {
        List<person> items;
        Activity context;
        public UsersListAdapter(Activity context, List<person> items) : base()
        {
            this.context = context;
            this.items = items;
        }
        public override person this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
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
            view = context.LayoutInflater.Inflate(Resource.Layout.layout2, null);
            view.FindViewById<TextView>(Resource.Id.tv1).Text = item.username;
            view.FindViewById<TextView>(Resource.Id.tv2).Text = item.age.ToString();
           
            return view;
        }
    }
