    using System.Linq;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    public static class Searcher
    {
        [MenuItem("Tools/PrintSearch")]
        public static void PrintSearch()
        {
            var objectName = "Space";
            var componentType = typeof(BoxCollider);
            var scenes = Enumerable.Range(0, SceneManager.sceneCount)
                .Select(SceneManager.GetSceneAt)
                .ToArray();
            var objectsWithNames = scenes
                .ToDictionary(s => s, s=> GetSceneObjectsWithName(s, objectName.ToLower()));
            var forLog = objectsWithNames
                .SelectMany(pair => pair.Value.Select(child =>
                    $"Scene {pair.Key.name}: object name '{child.gameObject.name}' {(child.GetComponent(componentType) != null ? "contains" : "do not contains")} component {componentType.Name}"));
            Debug.Log(string.Join("\n", forLog));
        }
        private static Transform[] GetSceneObjectsWithName(Scene scene, string objectName)
        {
            return scene.GetRootGameObjects()
                .SelectMany(g => GetChildHierarchyRecursively(g.transform))
                .Where(t=>t.gameObject.name.ToLower().Contains(objectName))
                .ToArray();
        }
        private static IEnumerable<Transform> GetChildHierarchyRecursively(Transform parentTransform)
        {
            yield return parentTransform;
            if (parentTransform.childCount > 0)
                yield return parentTransform;
        }
    }
