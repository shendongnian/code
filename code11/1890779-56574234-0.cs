    public class Yarn_IssueRecieveViewModel
    {
            public int YarnId { get; set; }
            // decimal/float/int as it is returned by the SP. 
            public decimal Receive { get; set; }
            public decimal Issued { get; set; }
            public decimal Claim { get; set; }
            public decimal Total { get; set; }
    }
