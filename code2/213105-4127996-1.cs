    string separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
    txtFoot.Text = txtFoot.Replace(".", separator).Replace(",", separator);
    txtInches.Text = txtInches.Replace(".", separator).Replace(",", separator);
    Double result = (Double.Parse(txtFoot.Text) * 30.48) + (Double.Parse(txtInches.Text) * 2.54);
    lblResult = result.ToString();
    lblFootAndInches = string.Format("{0}'{1}\"", txtFoot.Text, txtInches.Text);
