    void textBox_Changed(object sender, EventArgs e) {
      submitButton.Enabled = validator();
    }
    bool validator() {
      const string NON_POSITIVE = "Value must be greater than Zero";
      bool result = false;
      string controlName = "Length";
      try {
        _length = Convert.ToDouble(txtLength.Text);
        if (_length <= 0) throw new Exception(NON_POSITIVE);
        controlName = "Cross Section Area";
        _crossSectionArea = Convert.ToDouble(txtCrossSectionArea.Text);
        if (_crossSectionArea <= 0) throw new Exception(NON_POSITIVE);
        controlName = "Air Density";
        _airDensity = Convert.ToDouble(txtAirDensity.Text);
        if (_airDensity <= 0) throw new Exception(NON_POSITIVE);
        result = true; // only do this step last
      } catch (Exception err) {
        MessageBox.Show(controlName + " Error: " + err.Message, "Input Error");
      }
      return result;
    }
