        private void UpdateTotal()
        {
            Total = Convert.ToDouble(numCola.Value) * Cola;
            lblTotal.Text = $"{Total:C}";
        }
        private void numCola_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }
