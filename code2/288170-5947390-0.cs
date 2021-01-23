    public enum SomeEnum { item1, item2, item3 };
    public class Myclass
    {
        private SomeEnum enumItem;
        public SomeEnum EnumItem
        {
            get { return enumItem; }
            set { enumItem = value; }
        }
    }
