            lv_test = FindViewById<ListView>(Resource.Id.lv_test);
            
            lv_test.Adapter = adapter;
            lv_test.ItemClick += (s, e) =>
            {
                OnClick(e.Position);
            };
        public void OnClick(int position)
        {
          //call RemoveItemAt method in adapter
            adapter.RemoveItemAt(position);
          //notify the data changed
            adapter.NotifyDataSetChanged();
        }
