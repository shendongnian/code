csharp
public class GameScreen : BaseScreen
{
    // Add this ↓↓
    public CoinsSystem coinsSystem;
}
Then drag'n'drop your `CoinsSystem` asset from "Project" tab to your `GameScreen` component property that will be named "Coins System".
After that you can access your `CoinsSystem` via the `coinsSystem` variable, as such:
csharp
public class GameScreen : BaseScreen
{
    public CoinsSystem coinsSystem;
    public void OpenWinPopup()
    {
        coinsSystem.BuyCoins(500);
        OpenPopup<WinPopup>("Popups/WinPopup", popup =>
        {
            // *Rest of OpenPopup<WinPopup> code*
        });
    }
}
---
It is however bad habit referring to the serialized value on each value get/set. Recommended usage is via a variable and then have a dedicated `Save()` and `Load()` function. Partial example:
csharp
public class CoinsSystem : ScriptableObject
{
    private Action<int> onCoinsUpdated;
    public int coins;
    public void BuyCoins(int amount)
    {
        coins += amount;
        onCoinsUpdated?.Invoke(coins);
        // Optionally have this to save on each BuyCoins call:
        // Save()
    }
    public void Save()
    {
        PlayerPrefs.SetInt("num_coins", coins);
    }
    public void Load()
    {
        coins = PlayerPrefs.GetInt("num_coins");
    }
}
