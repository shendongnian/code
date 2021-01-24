     public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
          
            View view = inflater.Inflate(Resource.Layout.answers_fragment, container, false);
            expListView = view.FindViewById<ExpandableListView>(Resource.Id.answers);
            listAdapter = new AnswersListViewAdapter(Application.Context, answers); // This is where the implicit type conversion error occurs
            //view.FindViewById<ExpandableListView>(Resource.Id.answers).Adapter = new AnswersListViewAdapter(Context, answers);
            return view;
        }
