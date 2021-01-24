    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public List<Person> ReadFile(string path)
        {
            char[] charsToTrim1 = {'\\', ' ', '"', '\"'};
            var fileData = File.ReadAllLines(path);
            var outputData = new List<Person>();
            for (var i = 0; i < fileData.Length; i++)
            {
                var tmpData = fileData[i].Split(',');
                for (var j = 0; j < tmpData.Length; j++)
                {
                    var t1 = tmpData[j].Trim(charsToTrim1);
                    if (j == 0)
                        continue;
                    switch (i)
                    {
                        case 0:
                        {
                            var tmPerson = new Person {Name = t1};
                            outputData.Add(tmPerson);
                        }
                            break;
                        case 1:
                        {
                            outputData[j - 1].Address = t1;
                        }
                            break;
                        case 2:
                        {
                            outputData[j - 1].Age = Convert.ToInt32(t1);
                        }
                            break;
                    }
                }
            }
            return outputData;
        }
    }
