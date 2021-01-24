class Customer
{
    public string FName { get; set; }
    public string LName { get; set; }
    public string Phone { get; set; }
    public override string ToString()
    {
        return "FirstName: " + FName + ", LastName: " + LName + ", Phone: " + Phone;
    }
    public Customer(string fN, string lN, string ph)
    {
        FName = fN;
        LName = lN;
        Phone = ph;
    }
}
So the list show each items as you need.
You can adapt for what you want the list must display.
