    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.CompilerServices;
    
    using System.Globalization;
    
    using NLog;
    using NLog.Config;
    using NLog.LayoutRenderers;
    
    namespace MyNLogExtensions
    {
      [LayoutRenderer("StartTime")]
      class StartTimeLayoutRenderer : LayoutRenderer
      {
        private DateTime start = DateTime.Now;
        public StartTimeLayoutRenderer()
        {
          this.Format = "G";
          this.Culture = CultureInfo.InvariantCulture;
        }
    
        //
        // In NLog 1.x, LayoutRenderer defines a Culture property.
        // In NLog 2.0, LayoutRenderer does not define a Culture property.
        //
        public CultureInfo Culture { get; set; }
    
        [DefaultParameter]
        public string Format { get; set; }
    
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
          builder.Append(start.ToString(this.Format, this.Culture));
        }
    
        protected override int GetEstimatedBufferSize(LogEventInfo logEvent)
        {
          return 10;
        }
      }
    }
