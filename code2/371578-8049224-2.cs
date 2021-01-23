    static class PizzaFactory
    {
    	static Pizza CreatePizza(String topping)
    	{
    		if (topping == "cheese")
    		{
    			return new CheesePizza();
    		}
    		else if (topping == "salami")
    		{
    			return new SalamiPizza();
    		}
    	}
    }
    
    class Pizza { }
    class CheesePizza : Pizza { }
    class SalamiPizza : Pizza { }
