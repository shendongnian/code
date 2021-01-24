    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ActionNameAttribute : Attribute
    {
        public ActionNameAttribute(string name)
        {
            this.Name = name;
        }
        public string Name { get; }
    }
    [ActionName(nameof(AddUser))]
    public class DoActionAddUserBlock : BaseBlock<User, User, Context>
    {
        public override User Execute(User arg, Context context)
        {
            return AddUser(arg);
        }
    }
