        public int Grade { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return string.Format("Name{0} : Grade{1}", Name, Grade);
        }
    }
