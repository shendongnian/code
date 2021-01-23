<pre>
    static void contract_details(object sender, ContractDetailsEventArgs e) // This method has to be static.
    {
        Tester t = new Tester(); // This creates on each call an new Tester instances, which also deletes the list.
        t.MyOptionChainsInput(e.ContractDetails.Summary.Expiry, e.ContractDetails.Summary.Strike); // call the method on the instance
     }
