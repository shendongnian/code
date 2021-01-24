      class Program
      {
        static List<List<int>> Combos(List<int> listIn)
        {
          switch (listIn.Count)
          {
            case 0 : return new List<List<int>>();
            case 1 : return new List<List<int>> { listIn };
            default:
              var retList = new List<List<int>>();
              for (var i = 0; i < listIn.Count; i++)
              {
                var item = listIn[i];
                listIn.RemoveAt(i);
                var combos = Combos(listIn);
                foreach (var oneCombo in combos)
                {
                  var returnCombo = new List<int> { item };
                  returnCombo.AddRange(oneCombo);
                  retList.Add(returnCombo);
                }
                listIn.Insert(i, item);
              }
              return retList;
          }
        }
    
        static void Main(string[] args)
        {
          foreach (var l in Combos(new List<int>{1,2,3}))
          {
            foreach (var i in l)
              Console.Write($"{i} ");
            Console.WriteLine();
          }
          Console.ReadKey();
        }
      }
