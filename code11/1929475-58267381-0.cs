    using System.Linq;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    public static class EditorHelpers
    {
        [MenuItem("Tools/PrintHierarchy")]
        public static void PrintHierarchy()
        {
            var scenes = Enumerable.Range(0, SceneManager.sceneCount)
                .Select(SceneManager.GetSceneAt)
                .Select(s => $"Scene {s.name}\n{GetSceneHierarchy(s.GetRootGameObjects())}")
                .ToArray();
            Debug.Log(string.Join("\n", scenes));
        }
        private static string GetSceneHierarchy(GameObject[] gameObjects)
        {
            var child = gameObjects.Select(g => GetChildHierarchyRecursively(g.transform)).ToArray();
            return string.Join("\n", child);
        }
        private static string GetChildHierarchyRecursively(Transform parentTransform, string indent = " ")
        {
            var res = indent + parentTransform.name + "\n"
                      + string.Join("\n",
                          Enumerable.Range(0, parentTransform.childCount)
                              .Select(i => GetChildHierarchyRecursively(parentTransform.GetChild(i), indent += " ")));
            return res;
        }
    }
