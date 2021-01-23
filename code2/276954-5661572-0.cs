    {
          StringBuilder result = new StringBuilder();
          for (int i = 1; i < 101; i++)
          {
               var rest3 = i % 3;
               var rest5 = i % 5;
    
               if (rest3 == 0) result.Append("fizz");
               if (rest5 == 0) result.Append("bang");
               if (rest3 != 0 && rest5 != 0)
                   result.Append(i);
                    
               result.Append(System.Environment.NewLine);
          }
    }
