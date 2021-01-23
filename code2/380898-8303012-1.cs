        public void characterGeneration(string classSelected)
        {
            foreach (string classInList in classes.ClassList)
            {
                if (classSelected == classInList)
                {
                    PlayerOneStats = (GenerateStats)Assembly.GetExecutingAssembly().CreateInstance("YourNamespace." + classSelected);
                    break;
                }
            }
            PlayerOneStats.generateStats();
        }
