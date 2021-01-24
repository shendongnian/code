            List<MyObject> listMyObject = new List<MyObject>();
            listMyObject.Add(new MyObject() { Handle = 1, Name = "FirstName" });
            listMyObject.Add(new MyObject() { Handle = 2, Name = "SecondName" });
            listMyObject.Add(new MyObject() { Handle = 3, Name = "ThirdName" });
            List<MyObjectExtension> listMyObjectExtensions = new List<MyObjectExtension>();
            listMyObjectExtensions.Add(new MyObjectExtension() { Handle = 1, Description = "FirstDescription" });
            listMyObjectExtensions.Add(new MyObjectExtension() { Handle = 2, Description = "SecondDescription" });
            listMyObjectExtensions.Add(new MyObjectExtension() { Handle = 3, Description = "ThirdDescription" });
            IEnumerable<MyObject> MyObjects = listMyObject.AsEnumerable<MyObject>();
            IEnumerable<MyObjectExtension> MyObjectExtensions = listMyObjectExtensions.AsEnumerable<MyObjectExtension>();
            IEnumerable<MyRichObject> MyRichObjects;
            MyRichObjects = from myObject in MyObjects
                        join myObjectExtension in MyObjectExtensions on myObject.Handle equals myObjectExtension.Handle
                        select new MyRichObject { Handle = myObject.Handle, Name = myObject.Name, Description = myObjectExtension.Description };
            foreach (var MyRichObject in MyRichObjects)
            {
                System.Diagnostics.Debug.WriteLine($"Id: \"{MyRichObject.Handle}\". Name: {MyRichObject.Name}  Description: {MyRichObject.Description}");
            }
