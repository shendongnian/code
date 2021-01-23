    public class process_hook
    {
        public static List<String> pro_hook = list_all_pocesses();
        protected static string list_all_pocesses()
        {
            List<string> _list = new List<string>();
            foreach (Process i in Process.GetProcesses("."))
            {
                try
                {
                    foreach (ProcessModule pm in i.Modules)
                    {
                        _list.Add(pm.FileName.ToString());
                    }
                }
                catch { }
            }
            return _list;
        }
    }
