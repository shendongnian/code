    public static Dictionary<string, object> ConvertItemToDictionary(string Product, Dictionary<string, Price> pairs)
    {
        Dictionary<string, object> result = new Dictionary<string, object>();
        result.Add("Product", Product);
        foreach(var key in pairs.Keys)
        {
            pairs.TryGetValue(key, out Price price);
            result.Add($"{key}_L", price.Low);
            result.Add($"{key}_H", price.High);
        }
        return result;
    }
Use it in your main or other process,
    BindingList<QuoteboardRow> quoteboard = new BindingList<QuoteboardRow>();
    quoteboard.Add(
        new QuoteboardRow()
        {
            Product = "Cement",
            Prices = new Dictionary<string, Price>() {
        { "SupplierA",
            new Price() { Low= 101, High= 102 }
        },
        { "SupplierB",
            new Price() { Low= 101, High= 102 }
        },
        { "SupplierC",
            new Price() { Low= 101, High= 102 }
        }
            }
        }
    );
        
    var result = quoteboard.ToList().Select(x => ConvertItemToDictionary(x.Product, x.Prices)).ToList();
            
    Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
    dataGridView1.DataSource = result;
In the console, i had this as the output, which is what would print correctly in a transposed way. (I added pillar as a second entry for testing)
[
  {
    "Product": "Cement",
    "SupplierA_L": 101,
    "SupplierA_H": 102,
    "SupplierB_L": 101,
    "SupplierB_H": 102,
    "SupplierC_L": 101,
    "SupplierC_H": 102
  },
  {
    "Product": "pillar",
    "SupplierA_L": 101,
    "SupplierA_H": 104,
    "SupplierB_L": 101,
    "SupplierB_H": 101,
    "SupplierC_L": 101,
    "SupplierC_H": 105
  }
]
