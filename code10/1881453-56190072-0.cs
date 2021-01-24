    protected override void OnCreate(Bundle savedInstanceState) {
        base.OnCreate(savedInstanceState);
        RelativeLayout rl = new RelativeLayout(this);
        TextView tv1 = new TextView(this) {Id = View.GenerateViewId(), Text = "TextView #1"};
        RelativeLayout.LayoutParams parms1 = new RelativeLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
        parms1.AddRule(LayoutRules.AlignTop);
        tv1.LayoutParameters = parms1;
        rl.AddView(tv1);
        TextView tv2 = new TextView(this) {Id = View.GenerateViewId(), Text = "TextView #2"};
        RelativeLayout.LayoutParams parms2 = new RelativeLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
        parms2.AddRule(LayoutRules.Below, tv1.Id);
        tv2.LayoutParameters = parms2;
        rl.AddView(tv2);
        SetContentView(rl);
    }
