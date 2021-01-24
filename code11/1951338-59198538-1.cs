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
            var innerjoin = saleNumbersDK.Join(saleNumbersSE, d => d.VariantId, s => s.VariantId, (d, s) =>
            {
                return new SaleNumber()
                {
                    VariantId = d.VariantId,
                    ProductId = d.ProductId,
                    TotalSales = d.TotalSales+ (s == null ? 0 : s.TotalSales),
                    TotalSalesDK = d.TotalSales,
                    TotalSalesSE = (d == null ? 0 : d.TotalSales)
                };
            });
            var pendingright= saleNumbersSE.Except(innerjoin, new CustomComparer());
            var pendingleft = saleNumbersDK.Except(innerjoin, new CustomComparer());
            var salesNumber= innerjoin.Concat(pendingright).Concat(pendingleft);
            foreach (var sale in salesNumber)
            {
                Console.WriteLine(sale);
            }
            //Console.ReadLine();
        }
	
}
public class SaleNumber
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
public class CustomComparer : IEqualityComparer<SaleNumber>
    {
        public bool Equals(SaleNumber x, SaleNumber y)
        {
            return x.VariantId == y.VariantId;
        }
        public int GetHashCode(SaleNumber obj)
        {
            return obj.VariantId.GetHashCode();           
        }
    }
