    List<string> earnings = new List<string>() { "Housing Allowance", "Mobile Phone Allowance", "Mileage Allowance" };
    List<string> deductions = new List<string>() { "Housing Ban", "Mobile Phone Ban", "Mileage Ban" };
    treeView1.Nodes.Add("Component");//adding root node
    treeView1.Nodes[0].Nodes.Add("Earnings");//adding earnings child node
    treeView1.Nodes[0].Nodes.Add("Deductions");//adding deduction child node
    //adding all earnings to "Earnings" node
    foreach (string earning in earnings)
    {
        treeView1.Nodes[0].Nodes[0].Nodes.Add(earning);
    }
    //adding all deductions to "Deductions" node
    foreach (string deduction in deductions)
    {
        treeView1.Nodes[0].Nodes[1].Nodes.Add(deduction);
    }
