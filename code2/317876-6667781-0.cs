        public bool SomeMethod(object item)
        {
            var something = (SomeClass<SomeInterface>)item;
    
            return something.IsActive;
        }
