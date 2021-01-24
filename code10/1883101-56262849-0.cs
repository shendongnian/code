    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                List<RateFactorItem> recordA = GetRecordsA();
                List<RateFactorItem> recordB = GetRecordsB();
                var results = (from a in recordA
                               join b in recordB on a.Name equals b.Name
                               select new { a = a, b = b, name = a.Name}
                               )
                               .Select(x => (from ap in x.a.ProductValues
                                             join bp in x.b.ProductValues on ap.ProductName equals bp.ProductName into abp
                                             from bp in abp.DefaultIfEmpty()
                                             select new { ap = ap, bp = bp, name = x.name }
                                             ).ToList()
                               ).ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("Item", typeof(string));
                dt.Columns.Add("product", typeof(string));
                dt.Columns.Add("A Quantity", typeof(int));
                dt.Columns.Add("B Quantity", typeof(int));
                dt.Columns.Add("Variance", typeof(int));
                foreach (var item in results)
                {
                    foreach (var product in item)
                    {
                        DataRow newRow = dt.Rows.Add(new object[] {
                            product.name,
                            product.ap.ProductName,
                            product.ap.Value,
                            product.bp.Value,
                            (product.bp.Value == null) ? (int)product.ap.Value : Math.Abs((int)product.ap.Value - (int)product.bp.Value)
                        });
                        
                    }
                }
                dataGridView1.DataSource = dt;
            }
            public static List<RateFactorItem> GetRecordsA()
            {
                var items = new List<RateFactorItem>
                {
                    new RateFactorItem
                    {
                        Name = "Item1",
                        ProductValues = new List<ProductValues>
                    {
                        new ProductValues{ ProductName="product1", Value=200},
                        new ProductValues{ ProductName="product2", Value=300},
                        new ProductValues{ ProductName="product3", Value=400},
                        new ProductValues{ ProductName="product4", Value=500},
                        new ProductValues { ProductName = "product5", Value = 1000 },
                    }
                    },
                    new RateFactorItem
                    {
                        Name = "Item2",
                        ProductValues = new List<ProductValues>
                    {
                        new ProductValues{ ProductName="product1", Value=250},
                        new ProductValues{ ProductName="product2", Value=350},
                        new ProductValues{ ProductName="product3", Value=450},
                        new ProductValues{ ProductName="product4", Value=550},
                        new ProductValues { ProductName = "product5", Value = 1050 },
                    }
                    },
                    new RateFactorItem
                    {
                        Name = "Item3",
                        ProductValues = new List<ProductValues>
                    {
                        new ProductValues{ ProductName="product1", Value=2300},
                        new ProductValues{ ProductName="product2", Value=3030},
                        new ProductValues{ ProductName="product3", Value=4040},
                        new ProductValues{ ProductName="product4", Value=5030},
                        new ProductValues { ProductName = "product5", Value = 1400 },
                    }
                    },
                    new RateFactorItem
                    {
                        Name = "ItemX",
                        ProductValues = new List<ProductValues>
                    {
                        new ProductValues{ ProductName="product1", Value=20},
                        new ProductValues{ ProductName="product2", Value=30},
                        new ProductValues{ ProductName="product3", Value=40},
                        new ProductValues{ ProductName="product4", Value=50 },
                        new ProductValues { ProductName = "product5", Value = 60 },
                    }
                    }
                };
                return items;
            }
            public static List<RateFactorItem> GetRecordsB()
            {
                var items = new List<RateFactorItem>
                {
                    new RateFactorItem
                    {
                        Name = "Item1",
                        ProductValues = new List<ProductValues>
                        {
                            new ProductValues{ ProductName="product1", Value=230},
                            new ProductValues{ ProductName="product2", Value=340},
                            new ProductValues{ ProductName="product3", Value=470},
                            new ProductValues{ ProductName="product4", Value=590},
                            new ProductValues { ProductName = "product5", Value = 1010 },
                        }
                    },
                    new RateFactorItem
                    {
                        Name = "Item2",
                        ProductValues = new List<ProductValues>
                        {
                            new ProductValues{ ProductName="product1", Value=220},
                            new ProductValues{ ProductName="product2", Value=370},
                            new ProductValues{ ProductName="product3", Value=400},
                            new ProductValues{ ProductName="product4", Value=510},
                            new ProductValues { ProductName = "product5", Value = 150 },
                        }
                    },
                    new RateFactorItem
                    {
                        Name = "Item3",
                        ProductValues = new List<ProductValues>
                        {
                            new ProductValues{ ProductName="product1", Value=2900},
                            new ProductValues{ ProductName="product2", Value=3930},
                            new ProductValues{ ProductName="product3", Value=4940},
                            new ProductValues{ ProductName="product4", Value=5930},
                            new ProductValues { ProductName = "product5", Value = 1900 },
                        }
                        },
                    new RateFactorItem
                    {
                        Name = "ItemY",
                        ProductValues = new List<ProductValues>
                        {
                            new ProductValues{ ProductName="product1", Value=40},
                            new ProductValues{ ProductName="product2", Value=80},
                            new ProductValues{ ProductName="product3", Value=90},
                            new ProductValues{ ProductName="product4", Value=60 },
                            new ProductValues { ProductName = "product5", Value = 70 },
                        }
                     }
                };
                return items;
            }
        }
        public class RateFactorItem
        {
            public string Name { get; set; }
            public List<ProductValues> ProductValues { get; set; }
        }
        public class ProductValues
        {
            public string ProductName { get; set; }
            public double? Value { get; set; }
        }
    }
