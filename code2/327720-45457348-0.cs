         class Element
            {
                public string Company;        
                public string TypeOfInvestment;
                public decimal Worth;
            }
    
       class Program
        {
            static void Main(string[] args)
            {
             List<Element> elements = new List<Element>()
                {
                    new Element { Company = "JPMORGAN CHASE",TypeOfInvestment = "Stocks", Worth = 96983 },
                    new Element { Company = "AMER TOWER CORP",TypeOfInvestment = "Securities", Worth = 17141 },
                    new Element { Company = "ORACLE CORP",TypeOfInvestment = "Assets", Worth = 59372 },
                    new Element { Company = "PEPSICO INC",TypeOfInvestment = "Assets", Worth = 26516 },
                    new Element { Company = "PROCTER & GAMBL",TypeOfInvestment = "Stocks", Worth = 387050 },
                    new Element { Company = "QUASLCOMM INC",TypeOfInvestment = "Bonds", Worth = 196811 },
                    new Element { Company = "UTD TECHS CORP",TypeOfInvestment = "Bonds", Worth = 257429 },
                    new Element { Company = "WELLS FARGO-NEW",TypeOfInvestment = "Bank Account", Worth = 106600 },
                    new Element { Company = "FEDEX CORP",TypeOfInvestment = "Stocks", Worth = 103955 },
                    new Element { Company = "CVS CAREMARK CP",TypeOfInvestment = "Securities", Worth = 171048 },
                };
    
                //Group by on multiple column in LINQ (Query Method)
                var query = from e in elements
                            group e by new{e.TypeOfInvestment,e.Company} into eg
                            select new {eg.Key.TypeOfInvestment, eg.Key.Company, Points = eg.Sum(rl => rl.Worth)};
                          
    
    
                foreach (var item in query)
                {
                    Console.WriteLine(item.TypeOfInvestment.PadRight(20) + " " + item.Points.ToString());
                }
    
    
                //Group by on multiple column in LINQ (Lambda Method)
                var CompanyDetails =elements.GroupBy(s => new { s.Company, s.TypeOfInvestment})
                                   .Select(g =>
                                                new
                                                {
                                                    company = g.Key.Company,
                                                    TypeOfInvestment = g.Key.TypeOfInvestment,            
                                                    Balance = g.Sum(x => Math.Round(Convert.ToDecimal(x.Worth), 2)),
                                                }
                                          );
                foreach (var item in CompanyDetails)
                {
                    Console.WriteLine(item.TypeOfInvestment.PadRight(20) + " " + item.Balance.ToString());
                }
                Console.ReadLine();
    
            }
        }
