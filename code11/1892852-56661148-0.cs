          ///this code can help you  
            static void Main(string[] args)
              {
                   string query = "Select[MAKE],[YEAR] IN[FAKEDB].[FAKETABLE] WHERE[MAKE] " +
        "IN (*Makes*) AND [YEAR] IN (*Year*)";
             CarModel[] carModels = new CarModel[2] { new CarModel() { Make = "number1", Year = "1988" },
          new CarModel() { Make = "number2", Year = "2017" }
           };
            var result = SetQueryParameter(query, carModels);
          }
           public static string SetQueryParameter(string query, CarModel[] CarModels)
          {
            var makesStr = "(";
            var yearStr = "(";
            int counter = 1;
            foreach (var item in CarModels)
            {
                makesStr += item.Make; 
                yearStr += item.Year;
                if (CarModels.Count() != counter++)
                {
                    makesStr += ",";
                    yearStr += ",";
                }
                 
            }
           
            makesStr += ")";
            yearStr += ")";
            return query.Replace("(*Makes*)", makesStr).Replace("(*Year*)", yearStr);
        }
