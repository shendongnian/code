     using System.Threading.Tasks;
     
      Parallel.ForEach(enumerableList, p =>{   
                 parseEngine.Parse(p);   
         });
