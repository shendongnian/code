public class Customer
{
    public override string ToString()
    {
        return GetCustomer();
    }
    ...
}
So the list can show each items as you need.
You can adapt for what you want the list must display.
To use the constructor and to populate the listbox you need to write:
    private void LoadDB()
    {
      List<Customer> CustomerDB = new List<Customer>();
      CustomerDB.Add(new Customer("Tom", "Doe", "555-7654"));
      CustomerDB.Add(new Customer("Brad", "Pitt", "555-6543"));
      CustomerDB.Add(new Customer("Jill", "Jack", "555-5432"));
      CustomerDB.Add(new Customer("Peter", "Paul", "555-4321"));
      listBox1.Items.AddRange(CustomerDB.ToArray());
    }
If you want to keep the `CustomerDB` variable, you need to move it at the class level.
    public partial class Form1 : Form
    {
      List<Customer> CustomerDB = new List<Customer>();
      ...
    }
<br>
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/AXrMw.png
