      public class BaseClass
      {
         public int Property1 { get; set; }
         public int Property2 { get; set; }
         public virtual bool Submitted() { return (Property1 != 0); }
         public virtual bool Approved() { return (Property2 != 0); }
         // ...
      }
      public class Class1 : BaseClass
      {
         public string PropertyA { get; set; }
         public string PropertyB { get; set; }
         public override bool Submitted() 
         { return !String.IsNullOrEmpty(PropertyA); }
         public override bool Approved() 
         // Or do specific Class1 Approval actions...
         { return !String.IsNullOrEmpty(PropertyB); }
         // ...
      }
      public class Class2 : BaseClass
      {
         public string PropertyC { get; set; }
         public string PropertyD { get; set; }
         public override bool Submitted()
         { return !String.IsNullOrEmpty(PropertyC); }
         public override bool Approved()
         { return !String.IsNullOrEmpty(PropertyD); }
         // ...
      }
      public abstract class WorkflowState<PocoType> 
         where PocoType : BaseClass
      {
         private WorkflowManager<PocoType> _workflowManger;
         private PocoType _pocoObject;
         public WorkflowManager<PocoType> Workflow
         {
            get { return _workflowManger; }
            set { _workflowManger = value; }
         }
         public PocoType PocoObject
         {
            get { return _pocoObject; }
            set { _pocoObject = value; }
         }
         public abstract void Submitted();
         public abstract void Approved();
         // ...
      }
      public class InitialState<PocoType> : 
         WorkflowState<PocoType> where PocoType : BaseClass
      {
         public InitialState(PocoType pocoObject)
         {
            base.PocoObject = pocoObject;
         }
         public override void Submitted()
         {
            if (PocoObject.Submitted())
            {
               // move to approved state if submitted is ok for the poco
               // definition
               Workflow.State = new ApprovedState<PocoType>(this);
            }
         }
         public override void Approved()
         {
            // Not supported state
            throw new InvalidOperationException();
         }
         // ...
      }
      public class ApprovedState<PocoType> :
         WorkflowState<PocoType> where PocoType : BaseClass
      {
         public ApprovedState(WorkflowState<PocoType> state)
         {
            base.PocoObject = state.PocoObject;
            base.Workflow = state.Workflow;
         }
         public override void Submitted()
         {
            // Not supported state
            throw new InvalidOperationException();
         }
         public override void Approved()
         {
            if (PocoObject.Approved())
            {
               // next state ...
               //Workflow.State = ...
               //Send emails
               //Do approval items
            }
         }
      }
      public class WorkflowManager<PocoType> where PocoType : BaseClass
      {
         WorkflowState<PocoType> _state;
         public WorkflowManager(PocoType pocoObject)
         {
            this._state = new InitialState<PocoType>(pocoObject);
            this._state.Workflow = this;
         }
         public WorkflowState<PocoType> State
         {
            get { return _state; }
            set { _state = value; }
         }
         public void RunWorkflow()
         {
            State.Submitted();
            State.Approved();
         }
      }
