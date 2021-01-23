    public void RemoveLine(Product product) {
        for (var i = 0; i < lineCollection.Count;) {
            if (lineCollection[i].Product.ProductID == product.ProductID) {
                lineCollection.RemoveAt(i);
            } else { ++i; }
        }
    }
