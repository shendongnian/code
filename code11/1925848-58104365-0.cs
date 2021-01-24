        public interface ParentObject
        {
                int Id { get; set; }
                void ObjectAction(int value);
        }
        public class Object1 : ParentObject
        {
            public int Id { get; set; }
            public void ObjectAction(int value)
            {
                Console.WriteLine("I'm object #1 with value" + value);
            }
        }
        public class Object2 : ParentObject
        {
            public int Id { get; set; }
            public void ObjectAction(int value)
            {
                Console.WriteLine("I'm different object #2 with value" + value);
            }
        }
        public class UsingDifferentObjects
        {
                public Dictionary<string, ParentObject> GetProgress(int id)
                {
                        Dictionary<string, ParentObject> progresses = new Dictionary<string,ParentObject>();
                        var objtoAdd = (ParentObject)Activator.CreateInstance(Type.GetType($"Object{id}"));
                        objtoAdd.Id = id;
                        progresses.Add(id.ToString(), objtoAdd);
                        return progresses;
                }
        }
