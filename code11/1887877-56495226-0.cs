	using NHibernate;
	using NHibernate.Event;
	using NHibernate.Persister.Entity;
	public class EmployeePreLoadtListener : IPreLoadEventListener
	{
		public virtual void OnPreLoad(PreLoadEvent preloadEvent)
		{
			if (preloadEvent.Entity is Employee)
			{
				var employee = (Employee)preloadEvent.Entity;
				
				// do what you want with the object
				employee.Gender = null;
			}
		}
	}
