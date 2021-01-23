    using System.Linq;
    namespace UnityEngine {
    public static class GameObjectExtensionMethods {
        public static GameObject Find(this GameObject gameObject, string name, 
            bool inactive = false) {
           if (inactive)
              return Resources.FindObjectsOfTypeAll<GameObject>().Where(
                 a => a.name == name).FirstOrDefault();
           else
               return GameObject.Find(name);
        }
      }
    }
