	IEnumerator<Product> IEnumerable<Product>.GetEnumerator()
	{
		return Products.GetEnumerator();
	}
	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable<Product>)this).GetEnumerator();
	}
