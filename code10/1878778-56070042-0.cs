         public class Fragment1 : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.activity_main, container, false);
            ImageButton btnAddProject = view.FindViewById<ImageButton>(Resource.Id.btnAddProject);
            btnAddProject.Click += delegate
            {
                LayoutInflater layoutinflater = LayoutInflater.From(Activity);
                View DialogView = layoutinflater.Inflate(Resource.Layout.setup_project_name_dialog, null);
                Android.Support.V7.App.AlertDialog.Builder ProjectNameDialog = new Android.Support.V7.App.AlertDialog.Builder(Activity);
                ProjectNameDialog.SetView(DialogView);
                EditText editProjectName = DialogView.FindViewById<EditText>(Resource.Id.et_name);
                ProjectNameDialog.SetCancelable(false);
                ProjectNameDialog.SetPositiveButton("Continue", delegate
                {
                    //My own code here
                });
                ProjectNameDialog.Show();
            };
            return view;
        }
    }
