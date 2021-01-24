            // additional methods for getting appropriate instance of your class  
            public static List<Type> GetInterfaceTypes<Interface>()
            {
                Type serachInterface = typeof(Interface);
    
                List<Type> findClasses = serachInterface.Assembly.GetTypes().Where
                            (
                                t => t.IsClass && !t.IsAbstract &&
                                serachInterface.IsAssignableFrom(t)
                            ).ToList();
    
                return findClasses;
            }
            public static List<Interface> GetInstances<Interface>()
            {
                List<Interface> returnInstances = new List<Interface>();
                List<Type> foundTypes = GetInterfaceTypes<Interface>();
    
                foundTypes.ForEach(x =>
                {
                    returnInstances.Add((Interface)Activator.CreateInstance(x));
                });
                return returnInstances;
            }
           // your handler from PropertyGridViewModel.cs
            public IItem SelectedItem { get; private set; }
            public  void Handle(ItemSelectionMessage message)
            {
                IItem item = GetInstances<IItem>().FirstOrDefault(x => x.Visibility == message.Visibility);
                SelectedItem = item;
            }
    
            public class ItemSelectionMessage
           {
             public VisibilityStates Visibility { set; get; }
    
           }
       
    // enum that  is describe you visibility states
        public enum VisibilityStates
        {
            Button1,
            Button2
        }
    // interface and classes that are implemented visibility interface
        public interface IItem
        {
            VisibilityStates Visibility { get; }
        }
    
        public class Button1StateClass : IItem
        {
             public VisibilityStates Visibility { get => VisibilityStates.Button1; }
    
              [Browsable(true)]
              [Display(Order = 1, Name = "Object1", GroupName = "Objects", ResourceType typeof(Resources.DisplayNames), AutoGenerateField = true)]
    
                public ButtonViewModel Button1 { get; set; }
        }
        public class Button2StateClass : IItem
        {
              public VisibilityStates Visibility { get => VisibilityStates.Button2; }
              [Browsable(true)]
              [Display(Order = 2, Name = "Object2", GroupName = "Objects", ResourceType typeof(Resources.DisplayNames), AutoGenerateField = true)]
    
             public ButtonViewModel Button2 { get; set; }
        }
