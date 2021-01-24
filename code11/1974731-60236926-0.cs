if (UnityEditor.PrefabUtility.IsPartOfPrefabInstance(transform))
 
   UnityEditor.PrefabUtility.UnpackPrefabInstance(gameObject,
         UnityEditor.PrefabUnpackMode.Completely,
         UnityEditor.InteractionMode.AutomatedAction);
// Then I do DestroyImmediate();
And this:
var rootGO = PrefabUtility.LoadPrefabContents(pathToMyPrefab);
// Destroy child objects or components on rootGO
PrefabUtility.SaveAsPrefabAsset(rootGO, pathToMyPrefab);
prefabUtility.UnloadPrefabContents(rootGO);
