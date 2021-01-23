    namespace MonuEventPlanning
    {
        public partial class Form1 : Form
        {
            DinnerFun dinnerFun; // class level field declared here
     
        public Form1()
        {
            InitializeComponent();
            DinnerFun dinnerFun = new DinnerFun { PeepQty = (int)nudPeepQty.Value }; 
            // ^^^ local declaration, is NOT member field
        }
        public void btnCalc_Click(object sender, EventArgs e)
        {
            dinnerFun.CalcDrinks(cbxHealthy.Checked); // this is the member field, never initialized
