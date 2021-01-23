    // Wrapper class:
    public class Listener
    {
        public void Start()
        {
            bool useMono = true; // TODO: Get this from config
            if (!useMono)
            {
                // Bind directly to this as it will be available in Mono too
                HttpListener listener = new HttpListener();
                listener.Prefixes.Add("http://localhost:8081/foo/");
                listener.Prefixes.Add("http://127.0.0.1:8081/foo/");
                listener.Start();
            }
            else
            {
                Assembly asm = Assembly.Load("TheNameOfTheAssembly");
                Type type = asm.GetTypes().Where(x => x.Name == "TheType").FirstOrDefault();
                object obj = Activator.CreateInstance(type);
                MethodInfo mi = type.GetMethod("NameOfMethod");
                mi.Invoke(obj, null); // invoke with list of parameters
            }
        }
    }
