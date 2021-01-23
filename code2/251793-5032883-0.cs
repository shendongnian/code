    public class EffectType
    {
        public bool IsGpuBased { get; private set; }
    
        private EffectType(bool isGpuBased)
        {
            IsGpuBased = isGpuBased;
        }
    
        public static readonly EffectType PixelShader = new EffectType(true);
        public static readonly EffectType Blur = new EffectType(false);
    }
