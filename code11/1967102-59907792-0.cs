if(Decimal.TryParse(flower, out decimal parsedFlower))
{
   string resultString = parsedFlower.ToString("N2");
}
else
{
   // handling bad input
}
