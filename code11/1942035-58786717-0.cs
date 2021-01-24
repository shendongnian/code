    // GlobalVars.cs
    public class GlobalVars
    {
        // member variables
        private static Lazy<GlobalVars> INSTANCE = null;
        private ArrayList list = new ArrayList();
        // constructor
        private GlobalVars()
        {
        }
        // get single instance of GlobalVars from here
        public static GlobalVars getInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new Lazy<GlobalVars>(() => new GlobalVars());
            }
            return INSTANCE.Value;
        }
        // properties
        public ArrayList MyList { get => list; set => list = value; }
        // add others public properties in here
        // ...
    }
    // Form1.cs
    public partial class Form1 : Form
    {
        private GlobalVars globalVars;
        private Form2 form2;
        public Form1()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            // instance of GlobalVars 
            globalVars = GlobalVars.getInstance();
            // set capacity for 4 list
            globalVars.MyList.Capacity = 4;
            // add list1
            if (!globalVars.MyList.Contains("list1"))
            {
                globalVars.MyList.Add("list1");
            }
            // add list2
            if (!globalVars.MyList.Contains("list2"))
            {
                globalVars.MyList.Add("list2");
            }
            // show list1
            MessageBox.Show(globalVars.MyList[0].ToString());
            // show list2
            MessageBox.Show(globalVars.MyList[1].ToString());
            // show all list
            String items = "";
            for (int i = 0; i < globalVars.MyList.Count; i++)
            {
                items = items + globalVars.MyList[i].ToString() + "\n";
            }
            MessageBox.Show(items);
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            // show form2
            if(form2 == null) {
                form2 = new Form2();
            }
            form2.Show();
        }
    // Form2.cs
    public partial class Form2 : Form
    {
        GlobalVars globalVars;
        public Form2()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            // instance of GlobalVars 
            globalVars = GlobalVars.getInstance();
            // add list3
            if (!globalVars.MyList.Contains("list3"))
            {
                globalVars.MyList.Add("list3");
            }
            // add list4
            if (!globalVars.MyList.Contains("list4"))
            {
                globalVars.MyList.Add("list4");
            }
            // show list3
            MessageBox.Show(globalVars.MyList[2].ToString());
            // show list4
            MessageBox.Show(globalVars.MyList[3].ToString());
            // show all list
            String items = "";
            for (int i = 0; i < globalVars.MyList.Count; i++)
            {
                items = items + globalVars.MyList[i].ToString() + "\n";
            }
            MessageBox.Show(items);
        }
    }
