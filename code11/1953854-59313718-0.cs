    @page "/"
    @using System.Collections.Generic
    <h3>Display Customers</h3>
    <table class="table">
    <thead>
        <tr>
            <th>CustomerID</th>
            <th>Customer Name</th>
        </tr>
    </thead>
    <tbody>
        @foreach (var acustomer in thecustomers)
        {
            <tr>
                <td>acustomer.CustomerID</td>
                <td>acustomer.CustomerName</td>
            </tr>
        }
    </tbody>
    </table>
    @code {
        List<Customer2> thecustomers = new List<Customer2>();
    
        protected override void OnInitialized()
        {
            thecustomers.Add(new Customer2 { CustomerID = "123", CustomerName = "Any Company" });
            thecustomers.Add(new Customer2 { CustomerID = "456", CustomerName = "Some Company" });
        }
        public class Customer2
        {
            public string CustomerID { get; set; }
            public string CustomerName { get; set; }
        }
    }
