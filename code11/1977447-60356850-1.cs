while (true)
{
  Write("Enter in the area code you want to call: ");
  var input = ReadLine();
 
  if (input == "Exit")
      break;
  areaCode = Convert.ToInt32(input);
  x = 0;
           
while (x < phoneAreacode.Length && areaCode != phoneAreacode[x])
       ++x;      
  if(x != phoneAreacode.Length)
  {
       validAreacode = true;
        cost = phoneCost[x];
   }
  else if (validAreacode)
  {
      Write("Enter in the length of your call: ");
      callLength = Convert.ToInt32(ReadLine());
      double finalCost = callLength * cost;
      WriteLine("Your call to area code " + areaCode + " for " + callLength + " minutes will cost " + finalCost.ToString("C"));
  }
  else
  {
      WriteLine("YOU MUST ENTER A VALID AREA CODE!");
   }
}
Don't forget to add a check for when user types something that's not a digit
