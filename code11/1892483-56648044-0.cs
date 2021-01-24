     public class ListaCpf
       {
           public CPF[] CPFs { get; set; }
       }
     public class CPF
      {
          public string Numero { get; set; }
      }
      { 
            var aux = new List<CPF>();
            var cpf = new CPF
            {
                Numero = "13385860019"
            };
            var cpf2 = new CPF
            {
                Numero = "12283757720"
            };
            aux.Add(cpf);
            aux.Add(cpf2);
            var listaCpfs = new ListaCpf
            {
                CPFs = aux.ToArray()
              };
               var jsonCpf = JsonConvert.SerializeObject(listaCpfs);
