     <Image Source="someSourceUrl" RenderTransformOrigin="0.5, 0.5" CacheMode="BitmapCache">
         <Image.RenderTransform>
             <CompositeTransform x:Name="transform" />
         </Image.RenderTranform>
         <toolkit:GestureService.GestureListener>
             <toolkit:GestureListener PinchStarted="OnPinchStarted" PinchDelta="OnPinchDelta" />
         </toolkit:GestureService.GestureListener>
     </Image>
