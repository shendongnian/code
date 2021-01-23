    using System.Linq;
    using System.Windows.Controls.Primitives;
    
    Slider slider = new Slider();
    TextBlock tb = slider.GetVisualDescendants().OfType<TextBlock>().First();
