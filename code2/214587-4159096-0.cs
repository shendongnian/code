    ArrayList<decimal> FindSumSubset(decimal sum, ArrayList<decimal> list)
    {
       for (int i = 0; i < list.Length; i++)
       {
          decimal value = list[i];
          if (sum - value == 0.0m)
          {
              return new ArrayList<decimal>.Add(value);
          }
          else
          {
              var subset = FindSumSubset(sum - value, list.GetRange(i + 1, list.Length -i);
              if (subset != null)
              {
                  return subset.Add(value);
              }
          }
       }
       return null;
    }
