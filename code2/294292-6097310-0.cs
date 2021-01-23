    public abstract class Person<T> where T : Person<T>
    	{
    		public IEnumerable<T> Search()
    		{
    			DbDataReader reader = Database.Instance.ExecuteReader(sql);
    			while (reader.Read())
    			{
    				var row = new T();
    				row.Load(reader);
    				yield return row;
    			}
    		}
    
    		protected virtual void Load(DbDataReader reader){}
    	}
    
    	public class Programmer : Person<Programmer>{}
