        private void WriteInstanciationCodeFromObject(IList results)
        {
            //declare the object that will eventually house C# initialization code for this class
            var testMockObject = new System.Text.StringBuilder();
            //start building code for this object
            ConstructAndFillProperties(testMockObject, results);
            var codeOutput = testMockObject.ToString();
        }
        private void ConstructAndFillProperties(StringBuilder testMockObject, IList results)
        {
            testMockObject.AppendLine("var testMock = new " + results.GetType().ToString() + "();");
            foreach (object obj in results)
            {
                //if this object is a list, write code for it's contents
                if (obj.GetType().GetInterfaces().Contains(typeof(IList)))
                {
                    ConstructAndFillProperties(testMockObject, (IList)obj);
                }
                testMockObject.AppendLine("testMock.Add(new " + obj.GetType().Name + "() {");
                foreach (var property in obj.GetType().GetProperties())
                {
                   //if this property is a list, write code for it's contents
                    if (property.PropertyType.GetInterfaces().Contains(typeof(IList)))
                    {
                        ConstructAndFillProperties(testMockObject, (IList)property.GetValue(obj, null));
                    }
                    testMockObject.AppendLine(property.Name + " = (" + property.PropertyType + ")\"" + property.GetValue(obj, null) + "\",");
                }
                testMockObject.AppendLine("});");
            }
        }
