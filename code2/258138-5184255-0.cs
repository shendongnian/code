    public class Testing
    {
        private void Test()
        {
            var name = "A";
            var type = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Name == name).FirstOrDefault();
            var obj = Activator.CreateInstance(type);
        }
    }
    private class A
    { 
    }
