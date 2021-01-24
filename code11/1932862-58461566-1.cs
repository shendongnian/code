public WithProducts {
public List<Products> Products { get; set; } // Guessing. See what the collection is called in the result
}
(...)
JsonConvert.Deserialise<WithProducts>(json);
----
Btw. It's good practice to use a singular noun for class names e.g. `Product`, `Size` so you don't end up with `var oneProduct = new Products() {...}`.
