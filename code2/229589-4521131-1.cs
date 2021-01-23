<pre>
    // keep a static instance around
    static Tester tester = new Tester();
    static void contract_details(object sender, ContractDetailsEventArgs e) // This method has to be static.
    {
        // call the method on the static instance                
        tester.MyOptionChainsInput(e.ContractDetails.Summary.Expiry, e.ContractDetails.Summary.Strike); 
     }
