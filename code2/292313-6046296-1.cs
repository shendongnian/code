    public class Base1<T>
        where T: Base2
    {
        public List<T> MyThings { get; set; }
        protected Base1(List<T> listOfThings)
        {
            this.MyThings = listOfThings;
        }
    }
    public class Sub1 : Base1<Sub2>
    {
        public Sub1(List<Sub2> listofThings):
            base(listofThings)
        {
        }
    }
