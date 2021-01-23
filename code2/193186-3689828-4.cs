    using System.Windows.Forms;
    namespace MAPClient {
        class MAPCodeObjectCollection : ComboBox.ObjectCollection {
            public MAPCodeObjectCollection(ComboBox owner) : base(owner) { }
            new public int Add(object item) {
                // override
            }
            new public void Insert(int index, object item) {
                // override
            }
        }
    }
