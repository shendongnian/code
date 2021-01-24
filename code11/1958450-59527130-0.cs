       [Activity(Label = "MovieDetailActivity")]
    public class MovieDetailActivity : Activity
    {
        public  TextView textView;
        public  static MovieModel mMoviemodel;// define your model here
        public  static int mRowID;  // define a int variable mRowID
        public  static Intent createIntent(Context context, MovieModel movie, int rowID)
        {
            Intent intent = new Intent(context, typeof(MovieDetailActivity));
            //Pass parameters here
            mMoviemodel = movie; 
            mRowID = rowID;
            return intent;
        }
      protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.detaillayout);
            textView = FindViewById<TextView>(Resource.Id.info_textview);
           
            textView.Text = "movie name:" + mMoviemodel.mMovieName + " text = " + mRowID;
        }
    }
