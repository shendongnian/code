    public class ObjectData
    {
    }
    
    public class MyClass
    {
    	private List<ObjectData> _objects=new List<ObjectData>();
    	public ObjectsIndexer Objects{get{return new ObjectsIndexer(this);}}
    	
        public struct ObjectsIndexer
    	{
    		private MyClass _instance;
    		
    		internal ObjectsIndexer(MyClass instance)
    		{
    			_instance=instance;
    		}
    		
    		public ObjectData this[int index]
    		{
    			get
    			{
    				return _instance._objects[index-1];
    			}
    		}
    	}
    }
    	
    void Main()
    {
    		MyClass cls=new MyClass();
    		ObjectData data=cls.Objects[1];
    }
