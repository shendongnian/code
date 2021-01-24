    using Infragistics.UltraChart.Resources;
    using System;
    using System.Collections;
    using System.Data;
    
    namespace UltraGrid
    {
        public class DateTimeRenderer : IRenderLabel
        {
            readonly DataTable source;
            public DateTimeRenderer(DataTable dt)
            {
                source = dt;
            }
    
            public string ToString(Hashtable context)
            {
                double dataValue = (double)context["DATA_VALUE"];            
                var dt = new DateTime((long)dataValue);
                return dt.ToString("MM/dd/yyyy HH:mm:ss");
            }
        }
    
    }
