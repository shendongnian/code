    public partial class Form1 : Form
    {
        DinnerParty dinnerParty;
        public Form1()
        {
            InitializeComponent();
    
            dinnerParty = new DinnerParty().SetPartyOptions( 5, true );
    
            ...
