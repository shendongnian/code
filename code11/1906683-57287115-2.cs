    Then everytime spawing a new room it ads its own positions to the `occupiedPositions` so no other room can be spawned here anymore.
    Additionally check in which directions the room that is about to be added can even go and only pick a random room from that list using [`Linq Where`](https://docs.microsoft.com/dotnet/api/system.linq.enumerable.where).
    If there is no way left to go use the closed Room instead. (You could ofcourse still add it to the prefab lists if you also want the possibility of a randomly picked closed room)
        public class RoomSpawner : MonoBehaviour
        {
            [EnumFlags] public DoorType openingDirections;
        
            // Keep track of already used positions
            private static List<Vector2Int> occupiedPositions = new List<Vector2Int>();
        
            // store own room position
            private Vector2Int roomFieldPosition;
        
            private RoomTemplates templates;
            private bool spawned = false;
        
            private void Start()
            {
                templates = FindObjectOfType<RoomTemplates>();
        
                roomFieldPosition = new Vector2Int(Mathf.RoundToInt(transform.localPosition.x), Mathf.RoundToInt(transform.localPosition.z));
        
                occupiedPositions.Add(roomFieldPosition);
        
                Invoke("Spawn", 0.5f);
            }
        
            private static DoorType GetPossibleDirections(Vector2Int position)
            {
                DoorType output = 0;
        
                if (!occupiedPositions.Contains(new Vector2Int(position.x, position.y + 1))) output |= DoorType.Top;
                if (!occupiedPositions.Contains(new Vector2Int(position.x, position.y - 1))) output |= DoorType.Bottom;
        
                if (!occupiedPositions.Contains(new Vector2Int(position.x + 1, position.y))) output |= DoorType.Right;
                if (!occupiedPositions.Contains(new Vector2Int(position.x - 1, position.y))) output |= DoorType.Left;
        
                return output;
            }
        
            private void SpawnRoom(DoorType type)
            {
                Vector2Int nextPosition;
                RoomSpawner[] templateArray;
                RoomSpawner closedRoom;
        
                switch (type)
                {
                    case DoorType.Top:
                        nextPosition = new Vector2Int(roomFieldPosition.x, roomFieldPosition.y + 1);
                        templateArray = templates.topRooms;
                        closedRoom = templates.closedRoomTop;
                        break;
        
                    case DoorType.Right:
                        nextPosition = new Vector2Int(roomFieldPosition.x + 1, roomFieldPosition.y);
                        templateArray = templates.rightRooms;
                        closedRoom = templates.closedRoomRight;
                        break;
        
                    case DoorType.Bottom:
                        nextPosition = new Vector2Int(roomFieldPosition.x, roomFieldPosition.y - 1);
                        templateArray = templates.bottomRooms;
                        closedRoom = templates.closedRoomBottom;
                        break;
        
                    case DoorType.Left:
                        nextPosition = new Vector2Int(roomFieldPosition.x - 1, roomFieldPosition.y);
                        templateArray = templates.leftRooms;
                        closedRoom = templates.closedRoomLeft;
                        break;
        
                    default:
                        return;
                }
        
                if (occupiedPositions.Contains(nextPosition)) return;
        
                var directions = GetPossibleDirections(nextPosition);
        
                var prefabs = new List<RoomSpawner>();
                foreach (var doorType in (DoorType[])Enum.GetValues(typeof(DoorType)))
                {
                    if (!directions.HasFlag(doorType)) continue;
        
                    prefabs.AddRange(templateArray.Where(r => r.openingDirections.HasFlag(doorType)));
                }
        
                if (prefabs.Count == 0)
                {
                    prefabs.Add(closedRoom);
                }
        
                // Need to spawn a room with a BOTTOM door.
                var rand = Random.Range(0, prefabs.Count);
                Instantiate(prefabs[rand], new Vector3(nextPosition.x, 0, nextPosition.y), Quaternion.identity);
            }
        
            private void Spawn()
            {
                if (spawned) return;
        
                if (openingDirections.HasFlag(DoorType.Top)) SpawnRoom(DoorType.Top);
                if (openingDirections.HasFlag(DoorType.Bottom)) SpawnRoom(DoorType.Bottom);
        
                if (openingDirections.HasFlag(DoorType.Right)) SpawnRoom(DoorType.Right);
                if (openingDirections.HasFlag(DoorType.Left)) SpawnRoom(DoorType.Left);
        
                spawned = true;
            }
        }
    [![enter image description here][3]][3]
