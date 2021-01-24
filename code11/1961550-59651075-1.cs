public static event Action<int, string> OnInputReceived;
void InputReceived(int playerNumber, string direction)
{
    OnInputReceived?.Invoke(playerNumber, direction);
}
Within your PlayerMovementController.cs that should be attached to each individual player in the game, you should be tracking your playerId, or be able to check another attached script for the playerId:
public int playerId;
void Awake()
{
    GameManager.OnInputReceived += MovePlayer;
}
void MovePlayer(int inputPlayerId, string direction)
{
    if(inputPlayerId != playerId)
        return;
    else
    {
        //move THIS player in the "direction" using your movement logic
    }
}
void OnDestroy()
{
    GameManager.OnInputReceived -= MovePlayer;
}
If all of your players have unique ids and have the PlayerMovementController attached, they can now all listen to the inputs but only move when their ID is tied to it. If your GameManager calls InputReceived(1,"E"), all of your PlayerMovementControllers will call MovePlayer(1, "E"), but only the one with playerId == 1 will actually move since all of the others return immediately.
-- Diclaimer: All of this code is freehanded in StackOverflow, so there may be some syntax errors I didn't catch. Please let me know or edit it directly.
