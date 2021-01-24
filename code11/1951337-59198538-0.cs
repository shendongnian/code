using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
	 public static void Main(string[] args)
        {
            List<SaleNumber> saleNumbersDK = new List<SaleNumber> {
                new SaleNumber() { VariantId="a",ProductId="A",TotalSales=10 },
                new SaleNumber() { VariantId="b",ProductId="B",TotalSales=20 }
            };
            List<SaleNumber> saleNumbersSE = new List<SaleNumber> {
                new SaleNumber() { VariantId="a",ProductId="A",TotalSales=10 },
                new SaleNumber() { VariantId="c",ProductId="c",TotalSales=30 }
            };
            var salesNumber = saleNumbersDK.Join(saleNumbersSE, d => d.VariantId, s => s.VariantId, (d, s) =>
            {
                return new SaleNumber()
                {
                    VariantId = d.VariantId,
                    ProductId = d.ProductId,
                    TotalSales = d.TotalSales + (s == null ? 0 : s.TotalSales),
                    TotalSalesDK = d.TotalSales,
                    TotalSalesSE = (d == null ? 0 : d.TotalSales)
                };
            });
            foreach (var sale in salesNumber)
            {
                Console.WriteLine(sale);
            }
            //Console.ReadLine();
        }
	
}
internal class SaleNumber
    {
        public string VariantId { get; set; }
        public string ProductId { get; set; }
        public int TotalSales { get; set; }
        public int TotalSalesDK { get; set; }
        public int TotalSalesSE { get; set; }
        public override string ToString()
        {
            return VariantId+"-"+ProductId+"-"+TotalSales+"-"+TotalSalesDK+"-"+TotalSalesSE;
        }
    }
