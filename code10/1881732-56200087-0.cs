            BinaryFormatter formatter = new BinaryFormatter();
            DerivedClass object1 = new DerivedClass() { _baseField = "Object 1" };
            DerivedClass object2 = new DerivedClass() { _baseField = "Object 2" };
            using (FileStream writestream = new FileStream(@"data.bin", FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(writestream, object1);
                formatter.Serialize(writestream, object2);
            }
            FileStream readstream = new FileStream(@"data.bin", FileMode.Open, FileAccess.Read);
            DerivedClass deserializedobject1 = (DerivedClass)formatter.Deserialize(readstream);
            DerivedClass deserializedobject2 = (DerivedClass)formatter.Deserialize(readstream);
            readstream.Dispose();
