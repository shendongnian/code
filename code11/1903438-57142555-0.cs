     foreach (var item in numList.Select(x=> x.Number).Distinct())
            {
                 int counter = 0;
                  if(numList.Where(x=> x.Number.Equals(item)).Count() >= 10 )
                  { 
                      foreach( var item2 in numList.Where(x=> x.Number.Equals(item)) ){
                          if(counter <10 ) {
                              finalList.Add(item2);
                              counter ++;
                          }
                      }
                  }
            }
            foreach(var test in finalList)
                Console.WriteLine(string.Format("{0}, {1}", test.Number, test.Profit));
