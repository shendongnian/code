    public class StoreConsignorDetailAdapter: BaseAdapter<ScVsrList>
    {
        private StoreConsignorVsrObject item;
        AppCompatActivity activity;
        private List<ScVsrList> drList;  // defile variable drList
        public StoreConsignorDetailAdapter(AppCompatActivity activity, StoreConsignorVsrObject item)
        {
            this.item = item;
            this.activity = activity;
            this.drList = item.drList; // assign value to drList 
        }
        public override ScVsrList this[int position]
        {
            get
            {
                return drList[position];
            }
        }
        public override int Count
        {
            get
            {
                return drList.Count;
            }
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = drList[position];
            View view = convertView;
            if (view == null)
            {
                view = activity.LayoutInflater.Inflate(Resource.Layout.adapter_storeconsignorvsrmonitoring, null);
            }
            //var detail = drList.FirstOrDefault();
            view.FindViewById<TextView>(Resource.Id.txtViewVendorNum).Text = item.vnd.ToString();
            view.FindViewById<TextView>(Resource.Id.txtViewVdrNumber).Text = item.drref.ToString();
            view.FindViewById<TextView>(Resource.Id.txtViewTotal).Text = item.ctn.ToString();
            view.FindViewById<TextView>(Resource.Id.txtViewMvdr).Text = item.drList2.Count.ToString();
            view.FindViewById<TextView>(Resource.Id.txtViewDepartment).Text = item.dname;
            view.FindViewById<TextView>(Resource.Id.txtViewStatus).Text = "SHIPPED";
            return view;
        }
    }
