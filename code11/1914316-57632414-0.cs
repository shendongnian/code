    protected override void OnShown(EventArgs e) {
      base.OnShown(e);
      foreach (DataGridViewRow row in dgCustomerList.Rows)
      {
        var canHavePricingRowCells = row.Cells["CanHavePricing"].Value is null ? false : Convert.ToBoolean(row.Cells["CanHavePricing"].Value);
        var currentBidToValue = ((DataGridViewDisableButtonCell)row.Cells["Bid To"]).FormattedValue.ToString();
        if (canHavePricingRowCells is false || currentBidToValue == "No")
        {
          ((DataGridViewDisableButtonCell)row.Cells["btnCustomerCreateAgreement"]).Enabled = false;
        }
      }
    }
