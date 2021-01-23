    class BInputValues {
        public String Field1 { get; set; }
        //...
    };
    partial class FormB {
        readonly Action<BInputValues> callback;
        public FormB(Action<BInputValues> callback) {
            this.callback = callback;
        }
        protected override void btnOK_Click(object sender, EventArgs e) {
            callback(new BInputValues {
                Field1 = Field1.Text, 
                //...
            });
        }
    }
---
    override void btnAdd_click() {
        var formb = new FormB(args => {
            // do something with args
        });
        formb.ShowModal();
    }
