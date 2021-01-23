private void ChartClicked(object sender, someargs...)
{
   // Was it chart1 that was clicked? (We could use switch statement here to make the code cleaner)
   if (Object.Equals(sender, chart1)
   {
       // Do something to chart5
       chart5.Value = chart1.Value;
   }
}
