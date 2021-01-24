    public class MainActivity : AppCompatActivity
    {
        private Spinner spinner1, spinner2;
        private Button btnSubmit;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            addItemsOnSpinner1();
            addItemsOnSpinner2();
            addListenerOnButton();
        }
        
        public void addItemsOnSpinner1()
        {
            spinner1 = FindViewById<Spinner>(Resource.Id.spinner);
            spinner1.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.country_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner1.Adapter = adapter;
        }
        public void addItemsOnSpinner2()
        {
            spinner2 = (Spinner)FindViewById(Resource.Id.spinner2);
            List<String> list = new List<String>();
            list.Add("list 1");
            list.Add("list 2");
            list.Add("list 3");
            ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>(this,
                Android.Resource.Layout.SimpleSpinnerItem, list);  //simple_spinner_item
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);//simple_spinner_dropdown_item
            spinner2.Adapter = dataAdapter;
        }
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string toast = string.Format("Selected country is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }
        private void addListenerOnButton()
        {
            btnSubmit = (Button)FindViewById(Resource.Id.btnSubmit);
            btnSubmit.Click += BtnSubmit_Click;
        }
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this,
                "OnClickListener : " +
                "\nSpinner 1 : " + (spinner1.SelectedItem) +
                "\nSpinner 2 : " + (spinner2.SelectedItem),
            ToastLength.Short).Show();
        }
    }
