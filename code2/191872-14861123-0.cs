    public class Randomizator3000 
    {    
	public class Item<T>
	{
		public T value;
		public float weight;
		
		public static float GetTotalWeight<T>(Item<T>[] p_itens)
		{
			float __toReturn = 0;
			foreach(var item in p_itens)
			{
				__toReturn += item.weight;
			}
			
			return __toReturn;
		}
	}
	
	private static System.Random _randHolder;
	private static System.Random _random
	{
		get 
		{
			if(_randHolder == null)
				_randHolder = new System.Random();
			
			return _randHolder;
		}
	}
		
	public static T PickOne<T>(Item<T>[] p_itens)
	{	
		if(p_itens == null || p_itens.Length == 0)
		{
			return default(T);
		}
		
		float __randomizedValue = (float)_random.NextDouble() * (Item<T>.GetTotalWeight(p_itens));
		float __adding = 0;
		for(int i = 0; i < p_itens.Length; i ++)
		{
			float __cacheValue = p_itens[i].weight + __adding;
			if(__randomizedValue <= __cacheValue)
			{
				return p_itens[i].value;
			}
			
			__adding = __cacheValue;
		}
		
		return p_itens[p_itens.Length - 1].value;
		
	}
    }
