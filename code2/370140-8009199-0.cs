    class YourClass
    {
        public override string ToString()
        {
            return String.Format(CultureInfo.CurrentCulture,
                                 "Description: {0} {1}{2}{3}",
                                 this.Name,
                                 this.Age,
                                 Environment.NewLine,
                                 this.Email);
        }
    }
