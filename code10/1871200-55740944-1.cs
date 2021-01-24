    public class Object
    {
        public Object()
        {
            this.Objects3 = new List<Object3>();
        }
        public virtual ICollection<Object3> Objects3 { get; set; }
    }
    public class Object3
    {
        public virtual Object Object { get; set; }
    }
