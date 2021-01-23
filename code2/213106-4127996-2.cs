    string separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
    txtFoot.Text = txtFoot.Text.Replace(".", separator).Replace(",", separator);
    txtInches.Text = txtInches.Text.Replace(".", separator).Replace(",", separator);
    Double result = (Double.Parse(txtFoot.Text) * 30.48) + (Double.Parse(txtInches.Text) * 2.54);
    lblResult.Text = result.ToString();
    lblFootAndInches.Text = string.Format("{0}'{1}\"", txtFoot.Text, txtInches.Text);
