    public class CustomPicker : PickerRenderer
    {
        private Dialog dialog;
    
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            Control.Click += Control_Click1;
        }
    
    
        protected override void Dispose(bool disposing)
        {
            Control.Click -= Control_Click1;
            base.Dispose(disposing);
        }
    
        private void Control_Click1(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Picker model = Element;
            dialog = new Dialog(Forms.Context);
            dialog.SetContentView(Resource.Layout.custom_picker_dialog);
            Android.Widget.ListView listView = (Android.Widget.ListView)dialog.FindViewById(Resource.Id.listview);
            //listView.Adapter = new CustomPickerAdapter(((List<PickerModel>)model.ItemsSource), model.SelectedIndex);
            listView.Adapter = new MyAdaptr((List<string>)model.ItemsSource);
            listView.ItemClick += (object sender1, ItemClickEventArgs e1) =>
            {
                Element.SelectedIndex = e1.Position;
                dialog.Hide();
            };
            if (model.ItemsSource.Count > 3)
            {
                var height = Xamarin.Forms.Application.Current.MainPage.Height;
                var width = Xamarin.Forms.Application.Current.MainPage.Width;
                dialog.Window.SetLayout(700, 800);
                //dialog.Window.SetLayout(Convert.ToInt32(width * 2.70), Convert.ToInt32(height * 2));
            }
            dialog.Show();
        }
    
        class MyAdaptr : BaseAdapter
        {
            private IList<string> mList;
            public MyAdaptr(IList<string> itemsSource)
            {
                mList = itemsSource;
            }
    
    
    
            public override int Count => mList.Count;
    
    
    
            public override Java.Lang.Object GetItem(int position)
            {
                return mList[position];
            }
    
    
    
            public override long GetItemId(int position)
            {
                return position;
            }
    
    
    
            public override Android.Views.View GetView(int position, Android.Views.View convertView, ViewGroup parent)
            {
                Android.Views.View view = convertView;
                convertView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.celllayout, null);
                TextView text = convertView.FindViewById<TextView>(Resource.Id.textview1);
                text.Text = mList[position];
    
                return convertView;
            }
        }
    }
