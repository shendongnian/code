    public class ReportWrapper : IReport
    {
        MyObjectIsLikeReport inner;
        public ReportWrapper(MyObjectIsLikeReport obj) {
            this.inner = obj;
        }
        public void ReportMethod(int value) {
            this.inner.ReportMethod(value);
        }
        public int SomeProperty {
            get { return this.inner.SomeProperty; }
            set { this.inner.SomeProperty = value; }
        }
    }
