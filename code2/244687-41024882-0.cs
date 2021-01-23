        public static IList<T> GetAllControls<T>(Control control) where T : Control
        {
            var lst = new List<T>();
            foreach (Control item in control.Controls)
            {
                var ctr = item as T;
                if (ctr != null)
                    lst.Add(ctr);
                else
                    lst.AddRange(GetAllControls<T>(item));
            }
            return lst;
        }
