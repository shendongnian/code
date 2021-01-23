    using System.Collections.Generic;
    using System.Windows.Forms;
    namespace MAPClient {
        class MAPComboBox : ComboBox {
            private MAPCodeObjectCollection MAPCodeItemCollection = null;
            new public MAPCodeObjectCollection Items {
                // override
            }
            new public List<MAPCode> DataSource {
                // override
            }
            public MAPCodeComboBox() { }
        }
    }
