    public void ImportStartData()
        {
            foreach (string name in this.names)
            {
                if(!startData.ContainsKey(name)) //If this check is not done, then Dictionary will throw, duplicate key exception.
                {
                   this.startData.Add(name, this.ImportStartData(name));
                }
            }
        }
