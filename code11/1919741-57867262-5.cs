    public class MainActivity : AppCompatActivity, 
    Android.App.DatePickerDialog.IOnDateSetListener
    {
        private EditText editCalender;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            editCalender = FindViewById<EditText>(Resource.Id.editTextCalender);
            editCalender.Click += DateSelect_OnClick;
        }
        private void DateSelect_OnClick(object sender, EventArgs e)
        {
            var dialog = new DatePickerDialogFragment(this, DateTime.Now, this);
            dialog.Show(FragmentManager, "date");
        }
        public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        {
            var date = new DateTime(year, month + 1, dayOfMonth);
            editCalender.Text = date.ToString("MM/dd/yyyy");
        }
    }
