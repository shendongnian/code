    class YourAdapter : BaseAdapter,CompoundButton.IOnCheckedChangeListener
    {
        private Dictionary<int, bool> checkDictionary = new Dictionary<int, bool>();
        int[] item;  //raplace your own data
        public MyAdapter(int[] value) //raplace your own data
        {
            item = value;
            for (int i = 0; i < item.Length; i++)
            {
                checkDictionary.Add(i,false);
            }
        }
         public override View GetView(int position, View convertView, ViewGroup parent)
            {
                if (convertView == null)
                {
                    convertView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.layout6, null);
                }
                Switch sSwitch = convertView.FindViewById<Switch>(Resource.Id.SettingSwitch);
                sSwitch.SetOnCheckedChangeListener(null);
                sSwitch.Checked = checkDictionary[position];
                sSwitch.Tag = position;
                sSwitch.SetOnCheckedChangeListener(this);
                return convertView;
            }
        public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
            {
                var position = buttonView.Tag;
                //here store the correct state and do something you want
                checkDictionary[(int) position] = isChecked;
                
            }
     }
