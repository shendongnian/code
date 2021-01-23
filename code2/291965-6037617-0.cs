    public class BSE
    {
        virtual public int Prop 
        {
            get
            {
                return 6;
             }
         }
    }
    public class Derived : BSE
    {
        public override int Prop
        {
             get
             {
                 return 10;
             }
        }
     }
