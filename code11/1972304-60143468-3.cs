         public class MainActivity : AppCompatActivity
    {
        ListView lstViewData;
        List<Meeting> listSource = new List<Meeting>();
        Database db;
        EditText edtidLogin;
        EditText edtidContact;
        EditText edtPlace;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            lstViewData = FindViewById<ListView>(Resource.Id.listView);
             edtidLogin = FindViewById<EditText>(Resource.Id.edtidLogin);
             edtidContact = FindViewById<EditText>(Resource.Id.edtidContact);
             edtPlace = FindViewById<EditText>(Resource.Id.edtPlace);
            var btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
           
            db = new Database();
            db.createDatabase();
          //  InsertData(db);
          
            btnAdd.Click += BtnAdd_Click;
            LoadData();
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
        var meeting=    new Meeting() { idLogin= Int32.Parse( edtidLogin.Text), idContact= Int32.Parse(edtidContact.Text) , Place= edtPlace.Text };
            db.insertIntoTable(meeting);
            LoadData();
        }
        private void InsertData(Database db)
        {
            //throw new NotImplementedException();
            Meeting meeting = new Meeting() {
                idContact = 1,
                idLogin = 1,
                Place="Place1"
            };
             db.insertIntoTable(meeting);
            Meeting meeting2 = new Meeting()
            {
                idContact = 2,
                idLogin = 2,
                Place = "Place2"
            };
            db.insertIntoTable(meeting2);
            LoadData();
        }
        private void LoadData()
        {
            listSource = db.selectTable();
            var adapter = new ListViewAdapter(this, listSource);
            lstViewData.Adapter = adapter;
        }
