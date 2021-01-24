    [Activity(Label = "SpinnerActivity", MainLauncher = true)]
    public class SpinnerActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.spinner);
            Spinner sp = FindViewById<Spinner>(Resource.Id.spinner);
            List<MySpinnerItem> spinnerItems = new List<MySpinnerItem>();
            spinnerItems.Add(new MySpinnerItem("Red-",Color.Red));
            spinnerItems.Add(new MySpinnerItem("Yellow--", Color.Yellow));
            spinnerItems.Add(new MySpinnerItem("Green-----", Color.Green));
            spinnerItems.Add(new MySpinnerItem("Blue---", Color.Blue));
            spinnerItems.Add(new MySpinnerItem("Black--------", Color.Black));
            var spinnerAdapter = new MyAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, spinnerItems);
            sp.Adapter = spinnerAdapter;
        }
    }
    class MyAdapter : ArrayAdapter<MySpinnerItem>
    {
        public Context context;
        public List<MySpinnerItem> list;
        public int textViewResourceId;
        public MyAdapter(Context context, int textViewResourceId, List<MySpinnerItem> objects) : base(context, textViewResourceId, objects)
        {
            this.context = context;
            list = objects;
            this.textViewResourceId = textViewResourceId;
        }
        public override View GetDropDownView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                LayoutInflater inflater = LayoutInflater.From(context);
                convertView = inflater.Inflate(textViewResourceId, parent, false);
            }
            TextView tv = (TextView)convertView.FindViewById(Android.Resource.Id.Text1);
            tv.Text = list[position].Text;
            tv.SetTextColor(list[position].Color);
            return convertView;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                LayoutInflater inflater = LayoutInflater.From(context);
                convertView = inflater.Inflate(textViewResourceId, parent, false);
            }
            TextView tv = (TextView)convertView.FindViewById(Android.Resource.Id.Text1);
            tv.Text = list[position].Text;
            tv.SetTextColor(list[position].Color);
            return convertView;
        }
    }
    class MySpinnerItem
    {
        public string Text;
        public Color Color;
        public MySpinnerItem(string text, Color color)
        {
            Text = text;
            Color = color;
        }
    }
    
