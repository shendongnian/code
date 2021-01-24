    string test = "200| Άρχισε ξανά| Start again| test | test? |201,202,203,204 |list | picture]";
    int pos = -1;
    for ( int i = 1; i <= 5; i++)
    {
      pos = test.IndexOf('|', pos + 1);
      if ( pos == -1 )
        break;
    }
    string result = "";
    if ( pos != -1 )
      result = test.Substring(pos + 1).Trim();
    Console.WriteLine(result);
    Console.ReadKey();
