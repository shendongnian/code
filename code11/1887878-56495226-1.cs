	using NHibernate;
	using NHibernate.Event;
	using NHibernate.Persister.Entity;
	public class EmployeePostLoadtListener : IPostLoadEventListener
	{
		public virtual void OnPostLoad(PostLoadEvent postloadEvent)
		{
			if (postloadEvent.Entity is Employee)
			{
				var employee = (Employee)postloadEvent.Entity;
				
				// do what you want with the object
				employee.Gender = null;
			}
		}
	}
