if(!int.TryParse(txtYear.Text, out int intYear))
{
  throw new Exception("Only digits are allowed in the year field");
}
//the rest of your code goes here
//and use the intYear variable for the year parameter
