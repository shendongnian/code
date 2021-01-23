    public class process_hook
    {
        public static List<string> pro_hook = list_all_pocesses();
        protected static List<string> list_all_pocesses()
        {
            List<string> list = new List<string>();
            foreach (Process i in Process.GetProcesses("."))
            {
                foreach (ProcessModule pm in i.Modules)
                {
                    list.Add(pm.FileName.ToString());
                }
            }
            return list;
        }
    }
