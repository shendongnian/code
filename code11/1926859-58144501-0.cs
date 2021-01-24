    using System.Collections.Generic;
    class GameObject { }
    class Ball : GameObject { }
    class Rope : GameObject { }
    class Program {
        static GameObject[] _go = new GameObject[] {
            new Ball(),
            new Rope()
        };
        static List<TGameObject> ObjectsByType<TGameObject>() where TGameObject : GameObject {
            List<TGameObject> gameObjects = new List<TGameObject>();
            foreach (var gameObject in _go) {
                TGameObject tobj = gameObject as TGameObject;
                if (tobj != null) {
                    gameObjects.Add(tobj);
                }
            }
            return gameObjects;
        }
    }
