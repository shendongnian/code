    using Android.App;
    using Android.OS;
    using Android.Support.V7.App;
    using Android.Runtime;
    using Android.Widget;
    using System.Collections.Generic;
    using Android.Views;
    using System.Linq;
    namespace CC1_V1C
    {
    [Activity(Label = "@string/app_name")]
    public class MainActivity : AppCompatActivity
    {
        List<Eleve> listeEleves;
        GridView gv;
        Button Search;
         EditText classe;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            listeEleves = new List<Eleve>();
            gv = FindViewById<GridView>(Resource.Id.gridView1);
            Search = FindViewById<Button>(Resource.Id.button1);
            classe = FindViewById<EditText>(Resource.Id.editText1);
            //listeEleves.Add(new Eleve(Resource.Mipmap.ic_launcher_round));
            //listeEleves.Add(new Eleve(Resource.Mipmap.ic_launcher_round));
            //listeEleves.Add(new Eleve(Resource.Mipmap.ic_launcher_round));
            //listeEleves.Add(new Eleve(Resource.Mipmap.ic_launcher_round));
            // listeEleves.Add(new Eleve( Resource.Mipmap.ic_launcher_round));
            listeEleves.Add(new Eleve(1, "Ahmed", "Bida", 15, "Adresse1", "infos1", Resource.Mipmap.ic_launcher_round, "Classe1"));
            listeEleves.Add(new Eleve(2, "Ahmed2", "Bida2", 20, "Adresse2", "infos2", Resource.Mipmap.ic_launcher, "Classe2"));
            listeEleves.Add(new Eleve(3, "Ahmed3", "Bida3", 18, "Adresse3", "infos3", Resource.Mipmap.ic_launcher_round, "Classe3"));
            listeEleves.Add(new Eleve(4, "Ahmed4", "Bida4", 17, "Adresse4", "infos4", Resource.Mipmap.ic_launcher, "Classe4"));
            listeEleves.Add(new Eleve(5, "Ahmed5", "Bida5", 15, "Adresse5", "infos1", Resource.Mipmap.ic_launcher_round, "Classe1"));
            listeEleves.Add(new Eleve(6, "Ahmed6", "Bida6", 20, "Adresse6", "infos6", Resource.Mipmap.ic_launcher, "Classe2"));
            listeEleves.Add(new Eleve(7, "Ahmed7", "Bida7", 18, "Adresse7", "infos7", Resource.Mipmap.ic_launcher_round, "Classe3"));
            listeEleves.Add(new Eleve(8, "Ahmed8", "Bida8", 17, "Adresse8", "infos8", Resource.Mipmap.ic_launcher, "Classe4"));
            gv.Adapter = new gridView_Adapter(listeEleves, this);
            gv.ItemClick += Gv_ItemClick;
            Search.Click += Search_Click;
        }
        private void Search_Click(object sender, System.EventArgs e)
        {
            //var results = listeEleves.Where(E => E.Classe == Search.Text);
            
           listeEleves = listeEleves.Where(E => E.Classe == classe.Text).ToList();
            gv.Adapter = new gridView_Adapter(listeEleves, this);
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            return base.OnCreateOptionsMenu(menu);
        }
        private void Gv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var t = listeEleves[e.Position];
            FragmentTransaction ft = FragmentManager.BeginTransaction();
            fragment_Info f1 = new fragment_Info(listeEleves[e.Position]);
            
            f1.Show(ft,"ok");
            //View v = LayoutInflater.Inflate(Resource.Layout.layout_Eleves_Infos, null);
            
            //v.FindViewById<TextView>(Resource.Id.textView6).Text = t.GetCode().ToString();
            //v.FindViewById<TextView>(Resource.Id.textView7).Text = t.Nom.ToString();
            //v.FindViewById<TextView>(Resource.Id.textView8).Text = t.Prenom.ToString();
            //v.FindViewById<TextView>(Resource.Id.textView9).Text = t.GetAge().ToString();
            //v.FindViewById<TextView>(Resource.Id.textView10).Text = t.GetAdress().ToString();
            //v.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(t.Image);
            ////Button Fermer
            //Button Fermer = v.FindViewById<Button>(Resource.Id.button1);
            ////Code button Fermer
            //Fermer.Click += Fermer_Click;
            ////Creation de alert Dialog
            //ad = new Android.App.AlertDialog.Builder(this);
            //ad.SetTitle("Stagiaire Infos");
            //ad.SetIcon(Resource.Mipmap.ic_launcher);
            //ad.SetCancelable(true);
            //ad.SetView(v);
            //ad.Show();
        }
        //private void Fermer_Click(object sender, System.EventArgs e)
        //{
           
        //}
    }}
