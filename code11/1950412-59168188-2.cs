    [assembly: ExportRenderer(typeof(MyLablel), typeof(MyLablelRenderer))]
    namespace App18.Droid
    {
      class MyLablelRenderer:LabelRenderer
       {
          public MyLablelRenderer(Context context) : base(context)
           {
           }
          protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
           {
             base.OnElementChanged(e);
             if (Control != null)
              {              
                Control.SetTextColor(Android.Graphics.Color.Red);
              }
           }
        }
    }
