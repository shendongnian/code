    public partial class Form1 : Form, ICanDisplay
    { 
        public void disp(string strVal) 
        { //...
        } 
    }
    public partial class Form2 : Form, ICanDisplay
    {
        public void disp(string strVal) 
        { //...
        }
    }
    public interface ICanDisplay
    {
        void disp(string strVal);
    }
