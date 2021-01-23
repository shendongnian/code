    class MyClass : INotifyPropertyChanges
    {
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; NotifyPropertyChanged("Name"); }
        }
        public void UpdateFrom(string xml)
        {
            MyClass deserialized = Deserialize(xml);
            // here you set all properties you have
            Name = deserialized.Name;
            // and all the rest properties...
        }
        private static MyClass Deserialize(string xml)
        {
            XmlSerializer ser = new XmlSerializer(typeof(MyClass));
            using (StringReader reader = new StringReader(xml))
            {
                return (MyClass)ser.Deserialize(reader);
            }
        }
    }
