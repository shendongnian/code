    public partial class Form1 : Form
    {
        public int nWow;
        public Form1()
        {
            InitializeComponent();
            Inner.AssignMe(this); // This is where the real action is.
        }
        class Inner
        {
            static Form1 Me;
            static Inner(){} // empty static constructor necessary
               // Called AssignMe in the Form1 constructor in this code, 
               // but this can be generalized to any nested class.
            public static void AssignMe(Form1 form) { Me = form; }
            public Inner() { Me.nWow = 1; } // Now u can access public Form1
        }                        // members and methods even from the nested
    }                            // class' constructor.
