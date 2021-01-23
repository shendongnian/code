    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    
    [Designer(typeof(MyPanelDesigner))]
    public class MyPanel : Panel {
        private class MyPanelDesigner : ScrollableControlDesigner {
            public override SelectionRules SelectionRules {
                get { return SelectionRules.None; }
            }
        }
    }
