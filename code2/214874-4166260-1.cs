    public class MyPlugin :Plugin
    {
        private MyClass myClass;
        
        public MyPlugin()
        {
             this.myClass = new MyClass(this);  
             this.myClass.DoSomething();
        }
        public void Something()
        {
             //Called back into from MyClass
        }
    }
    public class Myclass
    {
         public Plugin OwnerPlugin {get;internal set;}
         public MyClass(Plugin ownerPlugin)
         {
               this.OwnerPlugin = ownerPlugin;
         }
         public void DoSomething()
         {
              //do something with ownerplugin
              this.OwnerPlugin.Something();
         } 
    }
