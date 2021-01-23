    if "mychild" is defined by the array , i think it can do well... 
    
    public class Parent
    {
        public Parent()
        {
            myChild = new Child[]{ new Child(){Value = "Value"}};
            //myChild2 = new Child() { Value = "Value" };
        }
        public Child[] myChild { get; set; }
        //public Child myChild2 { get; set; }
    }
