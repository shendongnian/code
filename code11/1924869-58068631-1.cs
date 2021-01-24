    public abstract class Build
    {
        [...]
        public abstract void AddSelfToGameObject(GameObject go);
    }
    public class Building:Build
    {
        [...]
        public override void AddSelfToGameObject(GameObject go)
        {
            go.AddComponent<BuildingScript>();
        }
    }
