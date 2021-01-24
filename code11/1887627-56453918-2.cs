    public class MyDialog: DialogFragment
    {
        Student student;
        public MyDialog(Student stu) {
            student = stu;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.layout_eleves_infos, container, false);
            TextView text_Nom = view.FindViewById<TextView>(Resource.Id.Nom_tv);
            text_Nom.Text = "Nom: " + student.Nom;
            TextView text_Prenom = view.FindViewById<TextView>(Resource.Id.Prenom_tv);
            text_Prenom.Text = "Prenom:" + student.Prenom;
            TextView text_age = view.FindViewById<TextView>(Resource.Id.Age_tv);
            text_age.Text = "Age: " + student.Age;
            TextView text_Address = view.FindViewById<TextView>(Resource.Id.Prenom_tv);
            text_Address.Text = "Addess: " + student.Adresse;
            ImageView image_iv = view.FindViewById<ImageView>(Resource.Id.image_iv);
            image_iv.SetImageResource(student.Image);
            return view;
        }
