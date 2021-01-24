    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication108
    {
        class Program
        {
            static void Main(string[] args)
            {
                string email = "john@email.com";
                DataBase db = new DataBase();
                var results = (from atr in db.Atributos
                               join fun in db.Funcionario on atr.Funcionario_Id equals fun.Id
                               join cen in db.CentroCusto on fun.CentroCusto_Id equals cen.Id
                               join ges in db.Gestors on cen.Gestor_Id equals ges.Id
                               where ges.Email == email
                               select new { desktop = atr.Desktop, notebook = atr.Notebook, gmail = atr.Gmail, tele = atr.Telefone, smartPhone = atr.Smartphone, rede = atr.Rede, outros = atr.Outros })
                               .ToList();
            }
        }
        public class DataBase
        {
            public List<Atributos> Atributos { get; set; }
            public List<Gestors> Gestors { get; set; }
            public List<Funcionario> Funcionario { get; set; }
            public List<CentroCusto> CentroCusto { get; set; }
        }
        public class Atributos
        {
            public string Funcionario_Id { get; set; }
            public string Desktop { get; set; }
            public string Notebook { get; set; }
            public string Gmail { get; set; }
            public string Telefone { get; set; }
            public string Smartphone { get; set; }
            public string Rede { get; set; }
            public string Outros { get; set; }
         }
        public class Gestors
        {
            public string Id { get; set; }
            public string Email { get; set; }
        }
        public class Funcionario
        {
            public string Id { get; set; }
            public string CentroCusto_Id { get; set; }
        }
        public class CentroCusto
        {
            public string Id { get; set; }
            public string Gestor_Id { get; set; }
        }
      
    }
