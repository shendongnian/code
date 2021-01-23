    public class Singleton<T> where T : new (){
            Singleton() { }
    
            public static T Instance
            {
                get { return SingletonCreator.instance; }
            }
    
            class SingletonCreator
            {
                static SingletonCreator() { }
    
                internal static readonly T instance = new T();
            }
    }
