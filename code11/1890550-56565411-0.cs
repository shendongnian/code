lang-csharp
public partial class Form1 : Form
{
    //Removed bInitialLoad, we'll set up the data table in the constructor.
    DataTable dtHardware = new DataTable("Hardware");
    Form2 multiServerView; //No longer initalizing here, we'll do that in the constructor.
    public Form1()
    {
        InitializeComponent();
        
        dtHardware.Columns.Add("ServerName", typeof(String));
        dtHardware.Columns.Add("Environment", typeof(String));
        multiServerView = new Form2(dtHardware);
        AddOwnedForm(multiServerView);
    }
    private void button1_Click(object sender, EventArgs e)
    {
        dtHardware.Clear();
        //Removed the check of bInitialLoad.
        DataRow drNewRow = dtHardware.NewRow();
        drNewRow["ServerName"] = "SomeName";
        drNewRow["Environment"] = "SomeEnvironment";
        dtHardware.Rows.Add(drNewRow);
        drNewRow = dtHardware.NewRow();
        drNewRow["ServerName"] = "SomeName2";
        drNewRow["Environment"] = "SomeEnvironment2";
        dtHardware.Rows.Add(drNewRow);
        //Removed setting bInitialLoad.
    }
    private void button2_Click(object sender, EventArgs e)
    {
        OpenMultiServerView();
    }
    private void OpenMultiServerView()
    {
        multiServerView.Show(); //Just show it.
    }
}
public partial class Form2 : Form
{
    DataView dvServers = null;
    //Removed the empty constructor since Form1 no longer needs it.
    public Form2(DataTable dt1)
    {
        InitializeComponent();
        dvServers = new DataView(dt1);
    }
    private void Form2_Load(object sender, EventArgs e)
    {
        listBox1.DisplayMember = "ServerName";
        listBox1.DataSource = dvServers;
    }
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        MessageBox.Show("I am the listbox event from Form2");
    }
    private void button1_Click(object sender, EventArgs e)
    {
        this.Close();
    }
    private void Form2_Closing(object sender, FormClosingEventArgs e)
    {
        //Don't forget to wire it up in the designer!
        //If the user clicks "button1" or the "X" then just hide the form.
        if (e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
This way, there is only ever one instance of `Form2` for `Form1`. You don't have to worry about instances of `Form2` that are disposed but not collected yet triggering events when something on `Form1` alters the data source.
