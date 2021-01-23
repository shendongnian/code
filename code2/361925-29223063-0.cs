    public partial class Form1 : Form
    {
        ob<Control>ob1;
        ob<Control>ob2;
        ob<Control>ob3;
        public Form1()
        {
            InitializeComponent();
            
            ob<Control>.setup(button1);
            ob1 = new ob<Control>(1, true);
            ob2 = new ob<Control>(2, false);
            ob3 = new ob<Control>(3, false);
        }
        public class ob<T> where T : Control
        {
            int ndx;
            Boolean isSentinel;
            static Boolean dontdostuff;
            static T c;
            public static void setup(T c) {ob<T>.c = c; }//an argument less from constructor, useful for many objects (more likely to be menuitems)
            public ob(int ndx, Boolean isSentinel)
            {
                this.isSentinel = isSentinel;
                this.ndx = ndx;
                c.Click += new EventHandler(click);
            }
            void click(object sender, EventArgs e) 
            { 
            			if( isSentinel)
                        {
                            if (MessageBox.Show("ob" + ndx + " asks:  short circuit delegate calls?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                        	    dontdostuff = true;
					            return;
                            }
                            else
                            {
                                dontdostuff = false;
                            }	
                        }
                        else
                        {
				            if( dontdostuff) return;
                        }
                     MessageBox.Show("ob" + ndx + " doing stuff in order of handler addition", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    
