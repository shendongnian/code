	public interface IDataNode
	{
		
	}
	
	public interface IDataNode<T> : IDataNode where T : IDataNode
	{
		T deepCopy(T parent);
		T getParent();
	}
	
	abstract class DataNode : IDataNode<DataNode>
	{
		public abstract DataNode deepCopy(DataNode parent);
	
		public DataNode getParent()
		{
			throw new NotImplementedException();
		}
	}
