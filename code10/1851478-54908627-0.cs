    public class Articolo
        {
            public varID codici { get; set; }
            public string varDescrizione { get; set; }
            public string varPrezzoUnitario { get; set; }
            public int varQuantita { get; set; }
            public string varAliquotaIVA { get; set; }
        }
        public class varID
        {
            public List<codicearticolo>  codice = new List<codicearticolo>();
                     
        }
        public class codicearticolo
        {
            public string varcodicetipo { get; set; }
            public string varcodicevalore { get; set; }
        }
        private List<Articolo> GetArticoloList()
        {
            //This method converts an xml file into a .csv file
            XDocument xDocument = XDocument.Load(@"c:\ft\test.xml");
            StringBuilder dataToBeWritten = new StringBuilder();
            var results = from x in xDocument.Descendants("DatiBeniServizi")
                          select new Articolo
                          {
                              codici = new varID()
                              {
                                  codice = new List<codicearticolo>(from code in x.Descendants("CodiceArticolo")
                                                                        select new codicearticolo
                                                                        {
                                                                            varcodicetipo = code.Element("CodiceTipo").Value,
                                                                            varcodicevalore = code.Element("CodiceValore").Value
                                                                        })
                              },
                              varDescrizione = x.Element("Descrizione").Value,
                              varPrezzoUnitario = x.Element("PrezzoUnitario").Value,
                             varQuantita  = Convert.ToInt32(x.Element("Quantita").Value),
                              varAliquotaIVA = x.Element("AliquotaIVA").Value
                          };
            
                return results.ToList();
         
        }
