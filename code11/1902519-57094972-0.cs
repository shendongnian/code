    public class ResourcesExtension
    {
        public static string ResourcesPath = Application.dataPath+"/Resources";
    
        public static UnityEngine.Object Load(string resourceName, System.Type systemTypeInstance) 
        {
        string[] directories = Directory.GetDirectories(ResourcesPath,"*",SearchOption.AllDirectories);
        foreach (var item in directories)
        {
            string itemPath = item.Substring(ResourcesPath.Length+1);
            UnityEngine.Object result = Resources.Load(itemPath+"\\"+resourceName,systemTypeInstance);
            if(result!=null)
                return result;
        }
        return null;
        }
    }
