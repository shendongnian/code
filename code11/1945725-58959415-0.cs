        public class WhereYouUseIt : MonoBehaviour
        {
            public Dictionary<Tile, GameObject> GetGameObject = new Dictionary<Tile, GameObject>();
            public Dictionary<GameObject, Tile> GetTile = new Dictionary<GameObject, Tile>();
    
            public void AddTileGameObjectPair(Tile tile, GameObject obj)
            {
                // Ofcourse you probably would want some checks 
                // e.g. if one of the references is already used as Key somewhere
                GetTile.Add(tile, obj);
                GetGameObject.Add(obj, tile);
            }
        }
