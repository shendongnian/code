    class GenericsExample1Class<T>
    {
        public string WhatsTheType(List<T> passedList)
        {
            string passedType = string.Empty;
            passedType = passedList.GetType().ToString();
            return passedType;
        }
    }
----------
        private void ClienMethod()
        {
            string typeOfTheList = string.Empty;
            // Call Type 1: Value Type
            List<int> intergerObjectList = new List<int> { 1, 2 };
            typeOfTheList = (new GenericsExample1Class<int>()).WhatsTheType(intergerObjectList);
            MessageBox.Show(typeOfTheList);
            // Call Type 2: Reference Type
            List<string> stringObjectList = new List<string> { "a", "b" };
            typeOfTheList = (new GenericsExample1Class<string>()).WhatsTheType(stringObjectList);
            MessageBox.Show(typeOfTheList);
            // Call Type 2: Complex-Reference Type
            List<Employee> complexObjectList = new List<Employee> { (new Employee { Id = 1, Name = "Tathagat" }), (new Employee { Id = 2, Name = "Einstein" }) };
            typeOfTheList = (new GenericsExample1Class<Employee>()).WhatsTheType(complexObjectList);
            MessageBox.Show(typeOfTheList);
        }
