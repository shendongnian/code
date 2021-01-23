	public class ProjectComparer : IEqualityComparer<Project>
	{
		public bool Equals(Project x, Project y)
		{
			if (x == null || y == null)
				return false;
			else
				return (x.ProjectID == y.ProjectID);
		}
		public int GetHashCode(Project obj)
		{
			return obj.ProjectID.GetHashCode();
		}
	}
