            Type t = this.GetType();
            while (t.Name != typeof(Object).Name) {
                Console.WriteLine(t.Name);
                t = t.BaseType;
            }
            Console.WriteLine(t.Name);
