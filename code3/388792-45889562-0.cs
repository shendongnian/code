    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Threading;
    using System.IO;
    using System.Timers;
    using System.Reflection;
    using System.Activities;
    using System.Activities.Statements;
    namespace WindowsFormsApplication7
    {
        public class UpdateLabel : CodeActivity
        {
    
            Action y;      
    
            public InArgument<Label> lbl { get; set; }
            public InArgument<string> text { get; set; }
    
    
            protected override void Execute(CodeActivityContext context)
            {
                ((Label)context.GetValue(lbl)).Invoke(y = () => ((Label)context.GetValue(lbl)).Text = context.GetValue(text).ToString());
            }
    
        }
    
    }
