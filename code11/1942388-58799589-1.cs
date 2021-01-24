public class Customer
{
    public string FName { get; set; }
    public string LName { get; set; }
    public string Phone { get; set; }
    public override string ToString()
    {
        return "FirstName: " + FName + ", LastName: " + LName + ", Phone: " + Phone;
    }
    public Customer()
    {
    }
    public Customer(string fN, string lN, string ph)
    {
        FName = fN;
        LName = lN;
        Phone = ph;
    }
}
So the list can show each items as you need.
You can adapt for what you want the list must display.
Then you can add in the `LoadDB` at the end:
    listBox1.Items.AddRange(CustomerDB.ToArray());
If you want to keep the `CustomerDB` variable, you need to move it at the class level.
