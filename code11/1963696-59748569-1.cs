    public abstract class Node
    {
        //attributes
        protected readonly int steps;
        public readonly int angleDeltaQ;
        private IUpdateVisitor updateVisitor;
        protected  Node():this(new DefaultUpdateVisitor())
        {
            
        }
        protected  Node(IUpdateVisitor visiter)
        {
            updateVisiter = visiter;
        }
        //constructor
        public Node(int steps, int angleDeltaQ)
        {
            this.steps = steps;
            this.angleDeltaQ = angleDeltaQ;
        }
        //methods
        public virtual int UpdateMe(Person me)
        {
                updateVisitor.UpdateMe(this,me);
        }
        public virtual void AssignMe(Person me)
        {
            me.steps = steps << me.speedRev;
        }
    }
    public interface IUpdateVisitor
    {
         int UpdateMe(Person me);
    }
    public class DefaultUpdateVisitor : IUpdateVisitor
    {
        public  int UpdateMe(Node node, Person me)
        {
            me.angleQ = QMath.RadLimitQ(me.angleQ + node.angleDeltaQ);
            me.xQ += QMath.CosQ(me.angleQ, me.speedRev);
            me.zQ += QMath.SinQ(me.angleQ, me.speedRev);
            me.steps--;
            if (me.steps == 0) return (int)node.NodeFeedback.targetReached;                
            else return (int)node.NodeFeedback.notFinished;
        }
    }
    public class AotherUpdateVisitor: IUpdateVisitor
    {
     public  int UpdateMe(Node node, Person me)
     {
         .....
     }   
    }
