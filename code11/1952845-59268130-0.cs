    public interface ICommon
    {
        string Name { get; set; }
    }
    public class Logic
    {
        private readonly List<ICommon> allMyObjects;
        private void InstantiateAllObjects(params Type[] list)
        {
            int c = 1;
            foreach (var t in list)
            {
                ICommon obj = (ICommon)System.Activator.CreateInstance(t);
                obj.Name = $"Object {c++:000}";
                allMyObjects.Add(obj);
            }
        }
    }
