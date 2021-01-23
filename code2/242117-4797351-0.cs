    using System;
    using System.Dynamic;
    
    class Program {
        static void Main(string[] args) {
            dynamic obj = new MyDynamicObject();
            obj.MyEvent += new EventHandler(handler);
            obj.MyEvent(null, EventArgs.Empty);
            obj.MyEvent -= new EventHandler(handler);
        }
        static void handler(object sender, EventArgs e) { }
    }
    
    class MyDynamicObject : DynamicObject {
        private EventHandler dlg = new EventHandler(delegate { });
        public override bool TryGetMember(GetMemberBinder binder, out object result) {
            result = dlg;
            return true;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value) {
            dlg = (EventHandler)value;
            return true;
        }
    }
