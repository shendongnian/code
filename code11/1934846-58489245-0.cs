c#
for(int i=0; i<game_count; i++) {
  if (Results[i*2] > Results[i*2+1])
    {
      Console.WriteLine("HW");
      ResultsG1 = "HW";
    }
    else if (Results[i*2] < Results[i*2+1])
    {
      Console.WriteLine("AW");
      ResultsG1 = "AW";
    }
    else
    {
      Console.WriteLine("D");
      ResultsG1 = "D";
    }
}
