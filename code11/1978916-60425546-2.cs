          public class MyAdapter : BaseAdapter<Progression>
    {
        private Activity mActivity;
        private List<Progression> items;
        public MyAdapter(Activity mActivity, List<Progression>  progressions)
        {
            this.mActivity = mActivity;
            this.items = progressions;
        }
       
        public override Progression this[int position] => items[position];
     
        public override int Count => items.Count();
        public override long GetItemId(int position)
        {
            return position;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = mActivity.LayoutInflater.Inflate(Resource.Layout.SimpleListItem1, null);
            view.FindViewById<TextView>(Resource.Id.textView1).Text = items[position].ProgressionIDs;
            view.FindViewById<TextView>(Resource.Id.textView2).Text = items[position].ProgressionNames;
            return view;
        }
    }
