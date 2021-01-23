    public partial class Fubar : UserControl
    {
        public property StateOfThings State { get; set; }
    }
    
    public enum StateOfThings
    {
        FU,
        BAR,
        FUBAR
    }
    <uc:Fubar runat="server" State="FU" />
