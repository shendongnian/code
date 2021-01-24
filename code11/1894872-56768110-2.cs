    CustomAdapter:
     public class Customadapter : BaseAdapter<Person>
    {
        public Activity activity;
        public ObservableCollection<Person> persons;
        public Customadapter(Activity activity, ObservableCollection<Person>persons):base()
        {
            this.activity = activity;
            this.persons = persons;
        }
        public override Person this[int position]
        {
            get
            {
                return persons[position];
            }
        }
        public override int Count
        {
            get
            {
                return persons.Count();
            }
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
        public override long GetItemId(int position)
        {
            return persons[position].Id;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            Person item = persons[position];
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.layout10, parent, false);
            var txtName = view.FindViewById<TextView>(Resource.Id.textView1);
            var txtAge =  view.FindViewById<TextView>(Resource.Id.textView2);
            var button = view.FindViewById<Button>(Resource.Id.button1);
            txtName.Text = persons[position].Name;
            txtAge.Text = " " + persons[position].Age;         
            button.Click += (object sender, EventArgs e) =>
              {
                  int index = (int)(((Button)sender).GetTag(Resource.Id.button1));
                  persons.RemoveAt(index);
                                
                  NotifyDataSetChanged();
                  
              };
            button.SetTag(Resource.Id.button1,position);
            return view;
        }
       
    }
