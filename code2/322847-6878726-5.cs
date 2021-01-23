	public PreparePizzas(IList<IPizza> pizzas)
	{
		foreach (IPizza pizza in pizzas)
			pizza.Prepare();
	}
