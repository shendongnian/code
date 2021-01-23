    public partial class frmAddress : Form
    {
    	BindingList<Address> _addressBindingList;
    
    	public frmAddress()
    	{
    		InitializeComponent();
    
    		_addressBindingList = new BindingList<Address>();
    		_addressBindingList.Add(new Address { Name = "Müller" });
    		_addressBindingList.Add(new Address { Name = "Aebi" });
    		lstAddress.DataSource = _addressBindingList;
    	}
    
    	private void btnChangeCity_Click(object sender, EventArgs e)
    	{
    		_addressBindingList[0].City = "Zürich";
    		_addressBindingList[1].City = "Burgdorf";
    	}
    }
