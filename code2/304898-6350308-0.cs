    public sealed class MyClass
    {
        private Data _data = new Data();
        //Properties go here (access the public fields on _data)
        public void Backup()
        {
            //Serialize Data
        }
        public void Restore()
        {
            //Deserialize Data and set new instance
        }
        private sealed class Data
        {
            //Public fields go here (they're private externally [because Data is private], but public to MyClass.)
        }
    }
