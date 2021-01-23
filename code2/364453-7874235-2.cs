	public interface IWorkflow {
		string UID { get; set; }	
		string parentID { get; set; }
		IList<IWorkflowStep> Steps { get; set; }
	}
	public interface IWorkflowStep {
		string UID { get; set; }	
		string parentID { get; set; }
	}
	 public class Workflow : IWorkflow, Node {
		
		public string UID { get; set; };
		public string parentID { get; set; };
		public IList<IWorkflowStep> Steps { get; set; }
	}
	public class WorkflowStep : IWorkflowStep, Node {
		public string UID { get; set; };
		public string parentID { get; set; };
	}
