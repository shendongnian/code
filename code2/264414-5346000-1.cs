var assemblyTypes = System.Reflection.Assembly.GetExecutingAssembly().GetTypes();
var instanceList = new List<IMyObject>();
foreach (Type currentType in assemblyTypes)
{
    if (currentType.GetInterface("IMyObject") == null) 
        continue;
                
    Console.WriteLine("Found type: {0}", currentType);
    // create instance and add to list
    instanceList.Add(Activator.CreateInstance(currentType) as IMyObject);
}
