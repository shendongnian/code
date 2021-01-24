// If you want to dynamically adjust the aspect ratio after creation
// this property should have logic in its setter to adjust the height request
public float DesiredAspectRatio { get; set; }
public MyControl()
{
   // Subscribe to the SizeChanged event in the constructor
   SizeChanged += HandleSizeChanged;
}
private void HandleSizeChanged(object sender, EventArgs e)
{
   if (this.Width > 0 && desiredAspectRatio > 0)
   {
       var desiredHeightRequest = this.Width / DesiredAspectRatio;
       // int it to make sure there's no weird recursive behavior
       // caused in release by how floats/doubles are handled.
       if((int)desiredHeightRequest != (int)HeightRequest)
       {
           this.HeightRequest = (int)desiredHeightRequest;
           InvalidateMeasure();
       }
   }
}
I'm not certain if `InvalidateMeasure` is necessary, but the code above worked for me.
