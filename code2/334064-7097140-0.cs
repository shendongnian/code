    public class Animal
	{
		public Animal(Animal otherAnimal)
		{
			if (otherAnimal == null)
				throw new ArgumentNullException("otherAnimal");
			foreach (System.Reflection.PropertyInfo property 
				in typeof(Animal).GetProperties())
			{
				property.SetValue(this, property.GetValue(otherAnimal, null), null);
			}
		}
	}
