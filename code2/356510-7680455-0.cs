       public partial class Form1 : Form
       {
          private ClientInfo _myClient;
          private BindingList<InsuranceDetails> all_insurance_types =
             new BindingList<InsuranceDetails>();
    
          public Form1()
          {
             InitializeComponent();
    
             DataGridView grid = new DataGridView();
             grid.Dock = DockStyle.Fill;
             grid.AutoGenerateColumns = true;
    
             all_insurance_types.Add(new InsuranceDetails(1, "Health"));
             all_insurance_types.Add(new InsuranceDetails(2, "Home"));
             all_insurance_types.Add(new InsuranceDetails(3, "Life"));
    
             var col = new DataGridViewComboBoxColumn
             {
                DataSource = all_insurance_types,
                HeaderText = "Insurance Type",
                DataPropertyName = "InsurDetailz",
                DisplayMember = "ItType",
                ValueMember = "Self",
             };
    
             _myClient = new ClientInfo { 
                InsurDetailz = all_insurance_types[2], Name = "Jimbo" };
             grid.Columns.Add(col);
             grid.DataSource = new BindingList<ClientInfo> { _myClient };
             this.Controls.Add(grid);
    
             this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
          }
    
          void Form1_FormClosing(object sender, FormClosingEventArgs e)
          {
             // make sure its updated
             InsuranceDetails c = _myClient.InsurDetailz;
             string name = _myClient.Name;
             // Place breakpoint here to see the changes in _myCar
             throw new NotImplementedException();
          }
       }
    
       class ClientInfo
       {
          public string Name { get; set; }
          public InsuranceDetails InsurDetailz { get; set; }
       }
    
       class InsuranceDetails
       {
          public int InsuranceTypeID { get; set; }
          public String ItType { get; set; }
          public InsuranceDetails Self { get { return this; } }
    
          public InsuranceDetails(int typeId, String itType)
          {
             this.InsuranceTypeID = typeId;
             this.ItType = itType;
          }
       }
