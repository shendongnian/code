	public interface IWorkflow {
		string UID { get; set; }	
		string parentID {get; set; }
	}
	public interface IWorkflowStep {
		string UID { get; set; }	
		string parentID {get; set; }
	}
	 public class Workflow : IWorkflow, Node {
		public string UID;
		public string parentID;
	}
	public class WorkflowStep : IWorkflowStep, Node {
		public string UID;
		public string parentID;
	}
