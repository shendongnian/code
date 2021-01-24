    [assembly: ExportRenderer(typeof(CustomSlider), typeof(CustomSliderRenderer))]
    namespace App8.iOS
    {
        public class CustomSliderRenderer : SliderRenderer
        {
    
        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);
    
            if (null != Control)
            {
                CustomSlider customSlider = (CustomSlider)e.NewElement;
                   
                customSlider.DragCompleted += CustomSlider_DragCompleted;
            
            }
        }
    
    
        private void CustomSlider_DragCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("------CustomSlider_DragCompleted-------");
        }
    
    }
