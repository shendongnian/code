      public class MainActivity : AppCompatActivity
    {
        GridView gv;
        List<Student> listStudents = new List<Student>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            gv = FindViewById<GridView>(Resource.Id.gridView1);
            //Search = FindViewById<Button>(Resource.Id.button1);
            //classe = FindViewById<EditText>(Resource.Id.editText1);
            listStudents.Add(new Student(1, "Ahmed", "Bida", 15, "Adresse1", "infos1", Resource.Mipmap.ic_launcher_round, "Classe1"));
            listStudents.Add(new Student(2, "Ahmed2", "Bida2", 20, "Adresse2", "infos2", Resource.Mipmap.ic_launcher, "Classe2"));
            listStudents.Add(new Student(3, "Ahmed3", "Bida3", 18, "Adresse3", "infos3", Resource.Mipmap.ic_launcher_round, "Classe3"));
            listStudents.Add(new Student(4, "Ahmed4", "Bida4", 17, "Adresse4", "infos4", Resource.Mipmap.ic_launcher, "Classe4"));
            listStudents.Add(new Student(5, "Ahmed5", "Bida5", 15, "Adresse5", "infos1", Resource.Mipmap.ic_launcher_round, "Classe1"));
            listStudents.Add(new Student(6, "Ahmed6", "Bida6", 20, "Adresse6", "infos6", Resource.Mipmap.ic_launcher, "Classe2"));
            listStudents.Add(new Student(7, "Ahmed7", "Bida7", 18, "Adresse7", "infos7", Resource.Mipmap.ic_launcher_round, "Classe3"));
            listStudents.Add(new Student(8, "Ahmed8", "Bida8", 17, "Adresse8", "infos8", Resource.Mipmap.ic_launcher, "Classe4"));
            gv.Adapter = new gridView_Adapter(listStudents, this);
            gv.ItemClick += Gv_ItemClick;
        }
        private void Gv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //FragmentTransaction ft = FragmentManager.BeginTransaction();
            //fragment_Info f1 = new fragment_Info();
            //f1.Show(ft, "ok");
            int position = e.Position;
            Student student = listStudents[position];
            AlertDialog.Builder dialog = new AlertDialog.Builder(this);
            AlertDialog alert = dialog.Create();
            alert.SetTitle("Student's Information");
            //alert.SetMessage("Complex Alert");
            //alert.SetIcon(Resource.Drawable.alert);
            LayoutInflater inflater = (LayoutInflater)this.GetSystemService(Context.LayoutInflaterService);
            View view = inflater.Inflate(Resource.Layout.layout_eleves_infos, null);
            alert.SetView(view);
            TextView text_Nom = view.FindViewById<TextView>(Resource.Id.Nom_tv);
            text_Nom.Text = "Nom: "+student.Nom;
            TextView text_Prenom = view.FindViewById<TextView>(Resource.Id.Prenom_tv);
            text_Prenom.Text = "Prenom:" + student.Prenom;
            TextView text_age = view.FindViewById<TextView>(Resource.Id.Age_tv);
            text_age.Text = "Age: "+ student.Age;
            TextView text_Address = view.FindViewById<TextView>(Resource.Id.Prenom_tv);
            text_Address.Text = "Addess: "+student.Adresse;
            ImageView image_iv = view.FindViewById<ImageView>(Resource.Id.image_iv);
            image_iv.SetImageResource(student.Image);
            alert.SetButton("OK", (c, ev) =>
            {
                // Ok button click task  
                string Nom = text_Nom.Text;
                string Prenom = text_Prenom.Text;
                Toast.MakeText(this, "Nom = " + Nom + " Prenom= " + Prenom, ToastLength.Long).Show();
            });
            alert.SetButton2("CANCEL", (c, ev) => { });
            alert.Show();
        }
    }
