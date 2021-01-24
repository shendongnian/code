    [assembly: ExportRenderer(typeof(MarqueeLabel), typeof(MaqueeTextRenderer))]
    namespace App18.Droid
    {
      class MaqueeTextRenderer :LabelRenderer
        {
          Context context;
          public MaqueeTextRenderer(Context context) : base(context)
            {
              this.context = context;
            }
          protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
            {
               base.OnElementChanged(e);
              if (Control != null)
               {
                 MaqueeText maqueeText = new MaqueeText(context);
                 maqueeText.SetSingleLine(true);
                 maqueeText.SetMarqueeRepeatLimit(-1);
                 maqueeText.Ellipsize = TextUtils.TruncateAt.Marquee;
                 maqueeText.Text = e.NewElement.Text;
                 SetNativeControl(maqueeText);
               }
            }
         }
    }
