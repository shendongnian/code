    // this.ckPosition.CheckedChanged += new System.EventHandler(this.ckPosition_CheckedChanged);
    private void ckPosition_CheckedChanged(object sender, EventArgs e)
    {
      txtX.Enabled = txtY.Enabled = ckPosition.Checked;
      numBearing.Enabled = numDistance.Enabled = !ckPosition.Checked;
    }
    // this.txtX.TextChanged += new System.EventHandler(this.Position_TextChanged);
    // this.txtY.TextChanged += new System.EventHandler(this.Position_TextChanged);
    private void Position_TextChanged(object sender, EventArgs e)
    {
      if (ckPosition.Checked)
      {
        // Replace with your calculations
        numBearing.Value = Convert.ToInt32(txtX.Text);
        numDistance.Value = Convert.ToInt32(txtY.Text);
      }
    }
    // this.numBearing.ValueChanged += new System.EventHandler(this.BearingDistance_ValueChanged);
    // this.numDistance.ValueChanged += new System.EventHandler(this.BearingDistance_ValueChanged);
    private void BearingDistance_ValueChanged(object sender, EventArgs e)
    {
      if (ckPosition.Checked == false)
      {
        // Replace with your calculations
        txtX.Text = numBearing.Value.ToString();
        txtY.Text = numDistance.Value.ToString();
      }
    }
