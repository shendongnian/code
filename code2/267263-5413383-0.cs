    public class Foo
    {
        [Import]
        private object ImportData { set { if(this.Data == null) this.Data = value } }
        
        public object Data { get; set; }
    }
