    public class c2 
    { 
        virtual public void Print() 
        { 
            MessageBox.Show("C2"); 
        }//print 
    }//c2 
 
    public class c1 : c2 
    { 
        override public void Print() 
        { 
            MessageBox.Show("C1"); 
            base.Print();
        }//print 
    }//c1 
