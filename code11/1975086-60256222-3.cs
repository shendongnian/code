protected override void OnSizeAllocated(double width, double height)
{
   base.OnSizeAllocated(width, height);
         
   if (CurrentDevice.IsOrientationPortrait() && width > height || !CurrentDevice.IsOrientationPortrait() && width < height)
   {
      int split;
      CurrentDevice.SetSize(width, height);
      // Orientation got changed! Do your changes here
      if (CurrentDevice.IsOrientationPortrait())
      {
         // portrait mode
         split = 2;
      }
      else
      {
         // landscape mode
         split = 4;
      }
      VideoCollectionView.ItemsLayout = new GridItemsLayout(split, ItemsLayoutOrientation.Vertical);
   }
         
             
}
