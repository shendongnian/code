     [assembly: ExportRenderer(typeof(MarqueeLabel), typeof(MarqueeLabelRenderer))]
     namespace Test.Forms.App.iOS.Renderer
      {
         public class MarqueeLabelRenderer : LabelRenderer
          {
            protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
             {
               var x = new MarqueeLabel.iOS.MarqueeLabel();
               SetNativeControl(x);
               base.OnElementChanged(e);
             }
         }
      }
