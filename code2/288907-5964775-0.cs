        public static List<T> FindControlsOfType<T>(Control ctlRoot)
        {
            List<T> controlsFound = new List<T>();
            if (typeof(T).IsInstanceOfType(ctlRoot))
                controlsFound.Add((T)(object)ctlRoot);
            foreach (Control ctlTemp in ctlRoot.Controls)
            {
                controlsFound.AddRange(FindControlsOfType<T>(ctlTemp));
            }
            return controlsFound;
        }
