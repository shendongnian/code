public WithProducts {
public List<Products> Products { get; set; } // Guessing. See what the collection is called in the result
}
(...)
JsonConvert.Deserialise<WithProducts>(json);
