    public class MyDropDownList : DropDownList
    {
        private SampleControl mySampleControl { get; set; }
    
        public int A
        {
            get
            {
                return mySampleControl.A;
            }
    
            set
            {
                mySampleControl.A = value;
            }
        }
    
        public int B
        {
            get
            {
                return mySampleControl.B;
            }
    
            set
            {
                mySampleControl.B = value;
            }
        }
    
        public MyDropDownList()
        {
            mySampleControl = new SampleControl();
        }
    
        protected override void OnLoad(EventArgs e)
        {
            //dummy task
            this.DataSource = mySampleControl.MysteryCollection;
            this.DataBind();
        }
    }
