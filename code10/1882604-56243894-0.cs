    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication3
    {
        class Program1
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> xDets = doc.Descendants("det").ToList();
                foreach (XElement xDet in xDets)
                {
                    Product newProduct = new Product();
                    Product.products.Add(newProduct);
                    newProduct.nItem = (int)xDet.Attribute("nItem");
                    XElement prod = xDet.Element("prod");
                    newProduct.cProd = (int)prod.Element("cProd");
                    newProduct.cEAN = (string)prod.Element("cEAN");
                    newProduct.xProd = (string)prod.Element("xProd");
                    newProduct.ncm = (string)prod.Element("NCM");
                    newProduct.cfop = (int)prod.Element("CFOP");
                    newProduct.uCom = (string)prod.Element("uCom");
                    newProduct.qCom = (decimal)prod.Element("qCom");
                    newProduct.vUnCom = (decimal)prod.Element("vUnCom");
                    newProduct.vProd = (decimal)prod.Element("vProd");
                    newProduct.indRegra = (string)prod.Element("indRegra");
                    newProduct.vItem = (decimal)prod.Element("vItem");
                    XElement obsFiscoDet = prod.Element("obsFiscoDet");
                    newProduct.xCampoDet = (string)obsFiscoDet.Attribute("xCampoDet");
                    newProduct.xTextoDet = (string)obsFiscoDet.Element("xTextoDet");
                    XElement imposto = xDet.Element("imposto");
                    newProduct.vItem12741 = (decimal)imposto.Element("vItem12741");
                    newProduct.orig = (int)imposto.Descendants("Orig").FirstOrDefault();
                    newProduct.CSOSN = (int)imposto.Descendants("CSOSN").FirstOrDefault();
                    newProduct.pICMS = (decimal?)imposto.Descendants("pICMS").FirstOrDefault();
                    newProduct.vICMS = (decimal?)imposto.Descendants("vICMS").FirstOrDefault();
                    XElement pis = imposto.Element("PIS");
                    newProduct.pissn_cst = (int)imposto.Descendants("CST").FirstOrDefault();
                    XElement cofins = imposto.Element("COFINS");
                    newProduct.cofinssn_cst = (int)cofins.Descendants("CST").FirstOrDefault();
                }
            }
        }
        public class Product
        {
            public static List<Product> products = new List<Product>();
            public int nItem { get; set; }
            public int cProd { get; set; }
            public string cEAN { get; set; }
            public string xProd { get; set; }
            public string ncm { get; set; }
            public int cfop { get; set; }
            public string uCom { get; set; }
            public decimal qCom { get; set; }
            public decimal vUnCom { get; set; }
            public decimal vProd { get; set; }
            public string indRegra { get; set; }
            public decimal vItem { get; set; }
            public string xCampoDet { get; set; }
            public string xTextoDet { get; set; }
            public decimal vItem12741 { get; set; }
            public int orig { get; set; }
            public int CSOSN { get; set; }
            public decimal? pICMS { get; set; }
            public decimal? vICMS { get; set; }
            public int pissn_cst { get; set; }
            public int cofinssn_cst { get; set; }
        }
     
    }
          //<imposto>
          //  <vItem12741>1.11</vItem12741>
          //  <ICMS>
          //    <ICMSSN900>
          //      <Orig>0</Orig>
          //      <CSOSN>900</CSOSN>
          //      <pICMS>18.00</pICMS>
          //      <vICMS>0.50</vICMS>
          //    </ICMSSN900>
          //  </ICMS>
          //  <PIS>
          //    <PISSN>
          //      <CST>49</CST>
          //    </PISSN>
          //  </PIS>
          //  <COFINS>
          //    <COFINSSN>
          //      <CST>49</CST>
          //    </COFINSSN>
          //  </COFINS>
          //</imposto>
