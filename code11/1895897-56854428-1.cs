    public class EdgeDetectionEffect : ShaderEffect
    {
        private static PixelShader _shader = new PixelShader { UriSource = new Uri("path to your compiled shader probably called cc.ps", UriKind.Absolute) };
    
    public EdgeDetectionEffect()
    {
        PixelShader = _shader;
        UpdateShaderValue(InputProperty);
        UpdateShaderValue(ActualHeightProperty);
        UpdateShaderValue(ActualWidthProperty);
        UpdateShaderValue(OutlineColorProperty);
        UpdateShaderValue(EdgeResponseProperty);
    }
        
    public Brush Input
    {
         get => (Brush)GetValue(InputProperty);
         set => SetValue(InputProperty, value);
    }
    public static readonly DependencyProperty InputProperty = 
        ShaderEffect.RegisterPixelShaderSamplerProperty(nameof(Input), 
        typeof(EdgeDetectionEffect), 0);
   
    public double ActualWidth
    {
         get => (double)GetValue(ActualWidthProperty);
         set => SetValue(ActualWidthProperty, value);
    }
    public static readonly DependencyProperty ActualWidthProperty =
        DependencyProperty.Register(nameof(ActualWidth), typeof(double), typeof(EdgeDetectionEffect),
        new UIPropertyMetadata(1.0, PixelShaderConstantCallback(0)));
    public double ActualHeight
    {
         get => (double)GetValue(ActualHeightProperty);
         set => SetValue(ActualHeightProperty, value);
    }
    public static readonly DependencyProperty ActualHeightProperty =
        DependencyProperty.Register(nameof(ActualHeight), typeof(double), typeof(EdgeDetectionEffect),
        new UIPropertyMetadata(1.0, PixelShaderConstantCallback(1)));
    public Color OutlineColor
    {
         get => (Color)GetValue(OutlineColorProperty);
         set => SetValue(OutlineColorProperty, value);
    }
    public static readonly DependencyProperty OutlineColorProperty=
        DependencyProperty.Register(nameof(OutlineColor), typeof(Color), typeof(EdgeDetectionEffect),
        new UIPropertyMetadata(Colors.Black, PixelShaderConstantCallback(2)));
    public double EdgeResponse
    {
         get => (double)GetValue(EdgeResponseProperty);
         set => SetValue(EdgeResponseProperty, value);
    }
    public static readonly DependencyProperty EdgeResponseProperty =
        DependencyProperty.Register(nameof(EdgeResponse), typeof(double), typeof(EdgeDetectionEffect),
        new UIPropertyMetadata(4.0, PixelShaderConstantCallback(3)));
         
