    using System.Collections.Generic;
    using System.Windows.Forms;
    namespace MAPClient {
        class MAPComboBox : ComboBox {
            private MAPCodeObjectCollection MAPCodeItemCollection = null;
            new public MAPCodeObjectCollection Items {
                get {
                    if (MAPCodeItemCollection == null) {
                        MAPCodeItemCollection = new MAPCodeObjectCollection(this);
                    }
                    return MAPCodeItemCollection;
                }
            }
            new public List<MAPCode> DataSource {
                get { return (List<MAPCode>) base.DataSource; } 
            
                set { base.DataSource = value; } 
            }
            public MAPCodeComboBox() { }
        }
    }
