    using System;
    using System.Windows.Forms;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Windows.Forms.Design;
    
    [Designer(typeof(MyControlDesigner))]
    public class MyControl : Control {
        public bool Prop { get; set; }
    }
