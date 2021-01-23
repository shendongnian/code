    class BaseObject {
        public BaseObject() {
            FieldInfo[] fInfos = this.GetType().GetFields(...);
            
            foreach (FieldInfo fInfo in fInfos) {
                object fInfoValue = fInfo.GetValue(this, null);
                if (fInfoValue is BaseObject) {
                    BaseObject bMemberObject = (BaseObject)fInfoValue;
                    bMemberObject.MyEvent += new EventHandler(delegate() {
                        if (this.MyEvent != null)
                            MyEvent();
                    });
                }
        }
        public event MyEvent = null;
    }
