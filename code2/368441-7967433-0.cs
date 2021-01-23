	public class GenericManager<T> :IGenericManager<T> where T : Updatable { }
	public interface IGenericManager<out T>	{ }
	public class Updatable { }
	class UpdatableX : Updatable {}
	class UpdatableY : Updatable {}
