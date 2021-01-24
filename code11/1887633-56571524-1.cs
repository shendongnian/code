    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Runtime;
    using Android.Util;
    using Android.Views;
    using Android.Widget;
    
    namespace CC1_V1C
    {
        public class fragment_Info : DialogFragment
        {
            List<Eleve> listeEleves = new List<Eleve>();
            Eleve E;
          public fragment_Info(Eleve ee)
          {
    
                this.E = ee;
          }
            
            public override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
    
                // Create your fragment here
            }
    
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
    
                // Use this to return your custom view for this Fragment
                // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
                //List
                
    
                listeEleves.Add(new Eleve(1, "Ahmed", "Bida", 15, "Adresse1", "infos1", Resource.Mipmap.ic_launcher_round, "Classe1"));
                listeEleves.Add(new Eleve(2, "Ahmed2", "Bida2", 20, "Adresse2", "infos2", Resource.Mipmap.ic_launcher, "Classe2"));
                listeEleves.Add(new Eleve(3, "Ahmed3", "Bida3", 18, "Adresse3", "infos3", Resource.Mipmap.ic_launcher_round, "Classe3"));
                listeEleves.Add(new Eleve(4, "Ahmed4", "Bida4", 17, "Adresse4", "infos4", Resource.Mipmap.ic_launcher, "Classe4"));
                listeEleves.Add(new Eleve(5, "Ahmed5", "Bida5", 15, "Adresse5", "infos1", Resource.Mipmap.ic_launcher_round, "Classe1"));
                listeEleves.Add(new Eleve(6, "Ahmed6", "Bida6", 20, "Adresse6", "infos6", Resource.Mipmap.ic_launcher, "Classe2"));
                listeEleves.Add(new Eleve(7, "Ahmed7", "Bida7", 18, "Adresse7", "infos7", Resource.Mipmap.ic_launcher_round, "Classe3"));
                listeEleves.Add(new Eleve(8, "Ahmed8", "Bida8", 17, "Adresse8", "infos8", Resource.Mipmap.ic_launcher, "Classe4"));
                base.OnCreateView(inflater, container, savedInstanceState);
                View v = inflater.Inflate(Resource.Layout.layout_Eleves_Infos, container,false);
                v.FindViewById<TextView>(Resource.Id.textView6).Text = E.Code.ToString() ;
                v.FindViewById<TextView>(Resource.Id.textView7).Text = E.Nom.ToString();
                v.FindViewById<TextView>(Resource.Id.textView8).Text = E.Prenom.ToString();
                v.FindViewById<TextView>(Resource.Id.textView9).Text = E.Age.ToString();
                v.FindViewById<TextView>(Resource.Id.textView10).Text = E.Adresse.ToString();
                v.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(E.Image);
    
    
    
    
                Button Close=v.FindViewById<Button>(Resource.Id.button1);
                Close.Click += Fermer_Click;
                return v;
               
            }
    
            private void Fermer_Click(object sender, EventArgs e)
            {
                this.Dismiss();
            }
        }
    }
