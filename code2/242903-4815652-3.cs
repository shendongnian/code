        private void BuildButtonToObjectDictionary()
        {
            int counter = 0;
            var assembly = Assembly.LoadFile(@"c:\components.dll");
            var buttonToObjectDictionary = (
                from type in assembly.GetTypes()
                where type.IsClass && !type.IsAbstract
                select new
                {
                    Button = new Button
                    {
                        Name = type.Name,
                        Text = type.Name,
                        Size = new Size(95, 25),
                        Location = new Point(175 + (counter * 100), 10),
                        UseVisualStyleBackColor = true
                    },
                    Item = Activator.CreateInstance(type),
                    Index = counter++
                }).ToDictionary((item) => item.Button);
        }
