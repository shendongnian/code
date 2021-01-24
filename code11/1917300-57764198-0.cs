    class RateLayout : LinearLayout
    {
        private RateChangeListener listener;
        protected RateLayout(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
       
        }
        public RateLayout(Context context) : base(context)
        {
  
            init(context);
        }
        public RateLayout(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            init(context);
        }
        public RateLayout(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            init(context);
        }
        public void SetRateChangeListener(RateChangeListener listener)
        {
            this.listener = listener;
        }
        private void init(Context context)
        {
            LinearLayout.LayoutParams parms = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
            View view = LayoutInflater.From(context).Inflate(Resource.Layout.rate_layout,null);
            view.LayoutParameters = parms;
            RatingBar death = view.FindViewById<RatingBar>(Resource.Id.arcanadeath);
            death.RatingBarChange += (sender, e) =>
            {
                listener.RateDeathChange((int)death.Rating);
            };
            RatingBar fate = view.FindViewById<RatingBar>(Resource.Id.arcanafate);
            fate.RatingBarChange += (sender, e) =>
            {
                listener.RateDeathChange((int)fate.Rating);
            };
            AddView(view);
        }
    }
