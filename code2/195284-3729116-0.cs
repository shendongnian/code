    class Singleton
    {
        static object locker = new Object();
    
        public static Singleton Instance
        {
            get
            {
                var inst = HttpContext.Current.Session["InstanceKey"] as Singleton;
                if (inst == null)
                {
                    lock (locker)
                    {
                        inst = HttpContext.Current.Session["InstanceKey"] as Singleton;
                        if (inst == null)
                        {
                            inst = new Singleton();
                            HttpContext.Current.Session["InstanceKey"] = inst;
                        }
                    }
                }
                return inst;
            }
        }
    }
