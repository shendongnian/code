    public class EFTData
    {
        public string Name { get; set; }
        public string RoutingNumber { get; set; }
        public string AccountNumber { get; set; }
        public string Id { get; set; }
        public void FromUSFormat(string sLine)
        {
            this.Id = sLine.Substring(0, 3);
            this.RoutingNumber = sLine.Substring(3, 7);
            this.Name = sLine.Substring(10, 20);
            this.AccountNumber = sLine.Substring(30, 7);
        }
        public string ToCanadianFormat()
        {
            var sbText = new System.Text.StringBuilder(100);
            // Note that you can pad or trim fields as needed here
            sbText.Append("A");
            sbText.Append(this.Id);
            sbText.Append(this.RoutingNumber);
            sbText.Append(this.AccountNumber);
            return sbText.ToString();
        }
    }
