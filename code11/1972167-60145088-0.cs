       public class ListViewAdapter : BaseAdapter<Meeting>
    {
        private Activity activity;
        private List<Meeting> listMeeting;
        public ListViewAdapter(Activity activity, List<Meeting> listMeeting)
        {
            this.activity = activity;
            this.listMeeting = listMeeting;
        }
        public override Meeting this[int position] => listMeeting[position];
        public override int Count
        {
            get { return listMeeting.Count; }
        }
        public override long GetItemId(int position)
        {
            return listMeeting[position].Id;
        }
        private int selectedId = -1;
        public void setSelectedId(int position)
        {
            selectedId = position;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = activity.LayoutInflater.Inflate(Resource.Layout.list_view, null);
        
            var txtName = view.FindViewById<TextView>(Resource.Id.idLogin);
            var txtDepart = view.FindViewById<TextView>(Resource.Id.idContact);
            var txtEmail = view.FindViewById<TextView>(Resource.Id.Place);
            txtName.Text = listMeeting[position].idLogin.ToString();
            txtDepart.Text = listMeeting[position].idContact.ToString();
            txtEmail.Text = listMeeting[position].Place;
            if (selectedId == position)
            {
                view.SetBackgroundColor(Color.Red);
             
            }
            else
            {
                view.SetBackgroundColor(Color.Transparent);
               
            }
            return view;
        }
      
    }
