    public static class Program     // the supporting class definitions are below
    {
        public static void Main()
        {
            // create a root container
            var room = new RoomContainer();
            // create a child
            var table = new Table(room, 4);
            
            // put the table in the room
            room.Add(table);
            MakeMess(room);
        }
        //  to show you how to access the properties 
        //  if you don't already have a reference:
        public static void MakeMess(RoomContainer room)
        {
            if(room == null)
            {
                throw new ArgumentNullException("room");
            }
            var seats = room.GetChildren<Table>().First().Seats.ToArray();
            for (int index = 0; index < seats.Length; index++)
            {
                Console.WriteLine("You have kicked over Seat #{0}",(index+1).ToString());
            }
        }
    }
    //  This is the base class of the components and provides the core functionality.
    //  You will want to make this object's interface minimal, so that the logic 
    //  is consistent with all its children (without knowing what they might be in advance)
    public abstract class Component
    {
        private readonly IList<Component> _children;
        private readonly Component _container;
        protected Component(Component container)
        {
            _container = container;
            _children = new Component[] { };
        }
        public bool IsRoot { get { return _container == null; } }
        public abstract bool IsContainer { get; }
        public virtual void Add(Component component)
        {
            if (component == null)
            {
                throw new ArgumentNullException("component");
            }
            if (!IsContainer)
            {
                throw new NotSupportedException("Add is not supported by leaf components");
            }
            _children.Add(component);
        }
        public IEnumerable<T> GetChildren<T>()
            where T: Component
        {
            if (!IsContainer)
            {
                throw new NotSupportedException("Only containers have children");
            }
            return _children.OfType<T>();
        }
        public IEnumerable<Component> Children
        {
            get
            {
                if (!IsContainer)
                {
                    throw new NotSupportedException("Only containers have children");
                } 
                return _children;
            }
        }
    }
    public class RoomContainer : Component
    {
        public RoomContainer() : base(null)
        {
        }
        public override bool IsContainer { get { return true; } }
    }
    public class Table : Component
    {
        private readonly int _maximumSeatCount;
        public Table(Component container, int maximumSeatCount) : base(container)
        {
            _maximumSeatCount = maximumSeatCount;
        }
        public override bool IsContainer { get { return true; } }
        protected virtual bool CanAdd(Component component)
        {
            return component is Seat && MaximumSeatCount > CurrentSeatCount;
        }
        public override void Add(Component component){
                if(CanAdd(component)){
                     base.Add(component);
                }
                else
                {
                    throw new NotSupportedException("The component was an invalid child of Table and could not be added.");
                }
           }
        public int MaximumSeatCount { get { return _maximumSeatCount; } }
        public int CurrentSeatCount { get { return Seats.Count(); } }
        public IEnumerable<Seat> Seats { get { return Children.OfType<Seat>(); } }
    } 
    public class Seat : Component
    {
        // you can restrict the constructor to only accept a valid parent
        public Seat(Table table) : base(table)
        {
        }
        public override bool IsContainer
        {
            get { return false; }
        }
    }
