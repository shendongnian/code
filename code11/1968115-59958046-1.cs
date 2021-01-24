    using UnityEditor;
    using UnityEngine;
    [ExecuteAlways]
    public class HierarchyMonitor : MonoBehaviour
    {
        static HierarchyMonitor()
        {
            EditorApplication.hierarchyChanged += OnHierarchyChanged;
        }
        static void OnHierarchyChanged()
        {
            Debug.Log("Heirarchy Has changed");
            //do you ring update here
        }
    }
