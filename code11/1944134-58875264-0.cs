 lang-csharp
decimal price;
//Price must be numeric
if(!Decimal.TryParse(txtPrice.Text, out price))
{
  MessageBox.Show("Price must be numeric", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
  txtPrice.Focus();
  return;
}
//price must be a positive number
if(price <= 0)
{
  MessageBox.Show("Price must be a positive number", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
  txtPrice.Focus();
  return;
}
