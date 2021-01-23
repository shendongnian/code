    using System.Windows.Forms;
    namespace MAPClient {
        class MAPCodeObjectCollection : ComboBox.ObjectCollection {
            public MAPCodeObjectCollection(ComboBox owner) : base(owner) { }
            new public int Add(object item) {
                if (item is MAPCode) {
                    return base.Add(item);
                }
            }
            new public void Insert(int index, object item) {
                if (item is MAPCode) {
                    base.Insert(index, item);
                }
            }
        }
    }
