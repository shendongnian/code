    // Base 1 hierachy
    abstract public class Base1
    {
        protected abstract Base2 GetBase2(int index); //we can't return the list directly
    }
    public class Base1<Base2Type> :Base1
        where Base2Type : Base2
    {
        public List<Base2Type> MyBase2s { get; set; }
        protected Base1(List<Base2Type> listOfThings)
        {
            this.MyBase2s = listOfThings;
        }
        protected override Base2  GetBase2(int index)
        {
 	        return MyBase2s[index];
        }
        
    }
    public class Sub1<MySub1Type,MySub2Type> : Base1<MySub2Type>
        where MySub1Type : Sub1<MySub1Type,MySub2Type>
        where MySub2Type : Sub2<MySub1Type, MySub2Type>
    {
        public Sub1(List<MySub2Type> listOfThings):
            base(listOfThings)
        {
            this.MyBase2s = listOfThings;
        }
    }
    public class Sub1 : Sub1<Sub1,Sub2>
    {
        public Sub1(List<Sub2> listofThings):
            base(listofThings)
        {
        }
    }
    // base 2 hirachy
    abstract public class Base2
    {
        protected abstract Base1 MyBase1 { get; }
    }
    public class Base2<Base1Type,Base2Type> : Base2
        where Base1Type: Base1<Base2Type>
        where Base2Type : Base2
    {
        public Base1Type myBase1;
        protected override Base1 MyBase1{ get {return myBase1;} }
    }
    public class Sub2<Sub1Type, Sub2Type> : Base2<Sub1Type,Sub2Type>
        where Sub1Type : Sub1<Sub1Type,Sub2Type>
        where Sub2Type : Sub2<Sub1Type,Sub2Type>
    {
    }
    public class Sub2 : Sub2<Sub1,Sub2>
    {
    }
