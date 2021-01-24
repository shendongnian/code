    using UnityEngine;
    using UnityEditor;
    public class CenterPivotEditor : MonoBehaviour
    {
        [MenuItem("Tools/CenterPivot")]
        private static void CenterPivot()
        {
            try
            {
            GameObject __PARENT = GameObject.Find("__PARENT");
            Vector3 centroid = Vector3.zero;
            Transform[] childs = __PARENT.transform.GetComponentsInChildren<Transform>();
            foreach (Transform go in childs)
            {
                Debug.Log(go.name);
                centroid += go.position;
            }
            centroid /= (__PARENT.transform.childCount);
            GameObject centerPivotObject = new GameObject();
            centerPivotObject.name = "CenterPivotObject";            
            centerPivotObject.transform.position = centroid;
            foreach (Transform go in childs)
            {
                go.parent = centerPivotObject.transform;
            }
            DestroyImmediate(__PARENT.gameObject);
        } catch(System.NullReferenceException notfound)
        {
            Debug.Log("__PARENT not found. Can't center pivot. Please rename GameObject to __PARENT in order to CenterPivot");
        }
        
        }
    }
