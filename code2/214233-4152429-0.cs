    //Parent form.    
    public partial class Form1 : Form
    {
        //This is the checkbox on your parent form
		CheckBox myCheckBox = new CheckBox();
		public Form1()
		{
			InitializeComponent();
			Form2 form2 = new Form2();
			form2.MyUncheckingEvent += new EventHandler(form2_MyUncheckingEvent);
		}
		void form2_MyUncheckingEvent(object sender, EventArgs e)
		{
			myCheckBox.Checked = false;
		}
	}
    //Child form    
    public partial class Form2 : Form
	{
		public event EventHandler MyUncheckingEvent;
		public Form2()
		{
			InitializeComponent();
		}
		public void MethodFormRaisingTheEvent()
		{
			if (MyUncheckingEvent != null)
			{
				MyUncheckingEvent(this, EventArgs.Empty);
			}
		}
	}
