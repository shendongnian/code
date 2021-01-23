        private void btnCalc_Click(object sender, EventArgs e)
        {
            DinnerFun dinnerFun = new DinnerFun { PeepQty = (int)nudPeepQty.Value };
            dinnerFun.CalcDrinks(cbxHealthy.Checked);
            dinnerFun.CalcDrinks(cbxFancy.Checked);
            DisplayCost(dinnerFun); 
        }
        public void DisplayCost(DinnerFun dinnerFun)
        {
            tbxDisplayCost.Text = dinnerFun.CalcTotalCost(cbxHealthy.Checked).ToString("c"); 
        }
