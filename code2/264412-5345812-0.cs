    public class MyObject1 : MyObjectBase
    {
        public string Column1 { get; set; }
        public override void Initialize(params object[] args)
        {
            this.Column1 = args[0];
        }
    }
    public class MyObject2 : MyObjectBase
    {
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public override void Initialize(params object[] args)
        {
            this.Column1 = args[0];
            this.Column2 = args[1];
        }
    }
    public class MyObject3 : MyObjectBase
    {
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }
        public override void Initialize(params object[] args)
        {
            this.Column1 = args[0];
            this.Column2 = args[1];
            this.Column3 = args[2];
        }
    }
    and so on.....
