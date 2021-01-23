	public class GenericManager<T> :IGenericManager<T> where T : Updatable { }
	public interface IGenericManager<out T>	where T : Updatable { }
	public class Updatable { }
	class UpdatableX : Updatable {}
	class UpdatableY : Updatable {}
