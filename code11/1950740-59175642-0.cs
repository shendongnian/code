    public class ResultSummaryFragment : Android.Support.V4.App.Fragment
    {
        private List<ResultSummary> data;
        public override async View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            Context context = Application.Context;
            View view = inflater.Inflate(Resource.Layout.results_summary_view, container, false);
            ListView listview = view.FindViewById<ListView>(Resource.Id.AllResultsListView);
            ISharedPreferences preferences = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
            string id = preferences.GetString("ID", string.Empty);
            if (id != null && data == null)
            {
                RunnerData RunnerData = new RunnerData(id);
                // This is not happening before OnCreateView?
                data = await RunnerData.GetAllResults();
            }
            //Now, your compiler knows that you need data and it will wait until data is obtained.
            ResultsSummaryListAdapter adapter = new ResultsSummaryListAdapter(context, data);
            listview.Adapter = adapter;
            return view;
        }
    }
