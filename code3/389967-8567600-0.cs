    int Max_Avg(string number_list)
    {
        var result = 0;
        var sum = 0;
        var count = 0;
        for (var i = 0; i < number_list.Length; i++)
        {
           if (number_list[i] == ',')
           {
              if (count > 0)
              {
                  result = math.Max(result, sum / count);
                  sum = 0;
                  count = 0;
              }
           }
           else
           {
              sum += number_list[i] - '0';
              count++;
           }
        }
        return result;
    }
