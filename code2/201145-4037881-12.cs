    using System;
    using System.Reflection;
    using System.Web;
    using System.Web.UI;
    
    namespace StackOverflow.Bounties.Web.UI
    {
        public class TraceablePage : Page
        {
            /// <summary>
            /// Gets or sets whether to render trace output.
            /// </summary>
            public bool EnableTraceOutput
            {
                get;
                set;
            }
    
            /// <summary>
            /// Abuses reflection to force the profiler's page output flag to true
            /// during an additional call to the page's trace rendering routine.
            /// </summary>
            protected override void Render(HtmlTextWriter writer)
            {
             	base.Render(writer);
             	if (!EnableTraceOutput) {
             	    return;
             	}
    
                // Allow access to private and internal members.
                BindingFlags evilFlags
                    = BindingFlags.Instance | BindingFlags.Static
                    | BindingFlags.Public | BindingFlags.NonPublic;
    
                // Profiler profiler = HttpRuntime.Profile;
                object profiler = typeof(HttpRuntime)
                    .GetProperty("Profile", evilFlags).GetGetMethod(true)
                    .Invoke(null, null);
    
                // profiler.PageOutput = true;
                profiler.GetType().GetProperty("PageOutput", evilFlags)
                    .GetSetMethod(true).Invoke(profiler, new object[] { true });
    
                // this.ProcessRequestEndTrace();
                typeof(Page).GetMethod("ProcessRequestEndTrace", evilFlags)
                    .Invoke(this, null);
    
                // profiler.PageOutput = false;
                profiler.GetType().GetProperty("PageOutput", evilFlags)
                    .GetSetMethod(true).Invoke(profiler, new object[] { false });
            }
        }
    }
