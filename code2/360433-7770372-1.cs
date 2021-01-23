    public class Employee
    {
       public string Name { get; set; }
       public int Id { get; set; }
       public bool IsChecked { get; set; }
    
       public override string ToString()
       {
          return Name;
       }
    }
    
    public partial class Form1 : Form
    {
       // Keep a bindable list of employees
       private BindingList<Employee> _employees;
   
       public Form1()
       {
          InitializeComponent();
          // Load some fake employees on load
          this.Load += new EventHandler(Form1_Load);
          // Click once to trigger checkbox changes
          checkedListBox1.CheckOnClick = true;
          // Look for item check change events (to update there check property)
          checkedListBox1.ItemCheck += 
             new ItemCheckEventHandler(CheckedListBox_ItemCheck);
       }
    
       // Load some fake data
       private void Form1_Load(object sender, EventArgs e)
       {
          _employees = new BindingList<Employee>();
          for (int i = 0; i < 10; i++)
          {
             _employees.Add(new Employee() 
                { Id = i, Name = "Employee " + i.ToString() });
          }
    
          // Display member doesnt seem to work, so using ToString override instead
          //checkedListBox1.DisplayMember = "Name";
          //checkedListBox1.ValueMember = "Name";
          checkedListBox1.DataSource = _employees;
   
          // Another example databind to show selection changes
          txtId.DataBindings.Add("Text", _employees, "Id");
          txtName.DataBindings.Add("Text", _employees, "Name");
       }
    
       // Item check changed, update the Employee IsChecked property
       private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
       {
          CheckedListBox clb = sender as CheckedListBox;
          if (clb != null)
          {
             Employee checked_employee = clb.Items[e.Index] as Employee;
             if (checked_employee != null)
             {
                checked_employee.IsChecked = (e.NewValue == CheckState.Checked);
             }
          }
       }
    
       // Just a simple test that removes an item from the list, rebinds it
       // and updates the selected values
       private void btnChangeList_Click(object sender, EventArgs e)
       {
          _employees.RemoveAt(1);
          checkedListBox1.DataSource = _employees;
 
          for (var i = 0; i < checkedListBox1.Items.Count; i++)
          {
             Employee employee_to_check = checkedListBox1.Items[i] as Employee;
             if (employee_to_check != null)
             {
                checkedListBox1.SetItemChecked(i, employee_to_check.IsChecked);
             }
          }
       }
    }
