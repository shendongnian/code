      static void Main(string[] args)
    {
        var flattedTree=new List<Person>();
        var Persons = new List<Person>();
        Persons.Add(new Person("Eric"));
        Persons[0].Childs = new List<Person>();
        Persons[0].Childs.Add(new Person("Tom"));
        Persons[0].Childs.Add(new Person("John"));
        Persons[0].Childs[0].Childs = new List<Person>();
        Persons[0].Childs[0].Childs.Add(new Person("Bill"));
        Persons.Add(new Person("John"));
        Flatten(Persons, flattedTree);
        //flattedTree variable is the flatted model of tree.
    }
     static void Flatten(List<Person> nodes, List<Person> flattedNodes)
            {
                foreach (var node in nodes)
                {
                    flattedNodes.Add(node);
                    if (node.Childs?.Count > 0)
                        Flatten(node.Childs, flattedNodes);
                }
            }
