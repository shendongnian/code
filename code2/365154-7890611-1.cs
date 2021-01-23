    namespace NLog.LayoutRenderers.Wrappers
    {
      using System.ComponentModel;
      using System.Globalization;
      using NLog.Config;
    
      [LayoutRenderer("Encrypt")]
      [AmbientProperty("Encrypt")]
      [ThreadAgnostic]
      public sealed class EncryptLayoutRendererWrapper : WrapperLayoutRendererBase    
      {
        public EncryptLayoutRendererWrapper()
        {
          this.Culture = CultureInfo.InvariantCulture;
          this.Encrypt = true;
        }
    
        [DefaultValue(true)]
        public bool Encrypt { get; set; }
    	  
        public CultureInfo Culture { get; set; }
    
        protected override string Transform(string text)
        {
          return this.Encrypt ? Encrypt(text) : text;
        }
    	  
        protected string Encrypt(string text)
        {
          //Encrypt your text here.
        }
      }
    }
