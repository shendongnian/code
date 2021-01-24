    using System.IO; 
    using System.Linq;
    ...
    List<marcacoes> list = ...
    File.WriteAllLines("marcacoes.txt", list
      .Select(item => string.Join(",", // join with "," following properties:
         item.Nome,                
         item.Hora,
         item.Minutos,
         item.Data.Year,
         item.Data.Month,
         item.Data.Day,
         item.Campo)));
