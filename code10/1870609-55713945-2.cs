    private static readonly List<List<int>> WinningCombinations = new List<List<int>>
    {
        new List<int> {1, 2, 3}, new List<int> {4, 5, 6}, new List<int> {7, 8, 9},
        new List<int> {3, 5, 7}, new List<int> {1, 4, 7}, new List<int> {2, 5, 8},
        new List<int> {3, 6, 9}
    };
    private static bool IsAWinner(List<int> playerCombination)
    {
        return WinningCombinations.Any(winningCombo =>
            playerCombination.Count == winningCombo.Count &&
            !winningCombo.Except(playerCombination).Any());
    }
