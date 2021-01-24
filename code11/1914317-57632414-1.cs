    void tabControl1_Selected(object sender, TabControlEventArgs e) {
      this.BeginInvoke(new Action(() => {
        foreach (DataGridViewRow row in dgCustomerList.Rows)
        {
          var canHavePricingRowCells = row.Cells["CanHavePricing"].Value is null ? false : Convert.ToBoolean(row.Cells["CanHavePricing"].Value);
          var currentBidToValue = ((DataGridViewDisableButtonCell)row.Cells["Bid To"]).FormattedValue.ToString();
          if (canHavePricingRowCells is false || currentBidToValue == "No")
          {
            ((DataGridViewDisableButtonCell)row.Cells["btnCustomerCreateAgreement"]).Enabled = false;
          }
        }
      }));
    }
