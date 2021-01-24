protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
{
   base.OnElementChanged(e);
   if(Control!=null)
   {
      SetNativeControl(new NativeImage());
   }
}
public class NativeImage : FormsUIImageView 
{
    public NativeImage() : base()
    {
         this.UserInteractionEnabled = true;
    }
    public override void TouchesBegan(NSSet touches, UIEvent evt)
    {
        base.TouchesBegan(touches, evt);
        Console.WriteLine("PIPPO touched");  //this (of course because no NativeImage is shown and there is no image to touch) is NOT logged
    }
}
  [1]: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/release-notes/4.4/4.4.0#namespace-xamarinformsplatformios
