    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.activity_main);
            // root layout
            var layout_main = new LinearLayout(this);
            LinearLayout.LayoutParams p1 = new LinearLayout.LayoutParams(
             LinearLayout.LayoutParams.MatchParent,
            LinearLayout.LayoutParams.WrapContent
            );
            layout_main.LayoutParameters = p1;
            layout_main.Orientation = Orientation.Vertical;
            // children 
            LinearLayout.LayoutParams param1 = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent, 1f);
            param1.SetMargins(5, 10, 5, 10);
            Random rand = new Random();
            int textViewCount = 10;
            TextView[] textViewArray = new TextView[textViewCount];
            for (int i = 0; i < textViewCount; i++)
            {
                textViewArray[i] = new TextView(this);
                textViewArray[i].LayoutParameters = param1;
                textViewArray[i].SetBackgroundColor(Color.Yellow);
                textViewArray[i].Gravity = GravityFlags.CenterHorizontal;
                textViewArray[i].Text = rand.Next(1, 16).ToString();
                layout_main.AddView(textViewArray[i]);
            }
            // Set our view from the "main" layout resource
            SetContentView(layout_main);
        }
    }
