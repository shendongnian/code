    public sealed class ButtonListControl : MonoBehaviour
    {
        private GameObject[] ApplianceList;
        // Hide every button except the one with the given index
        public void HideAllBut(int index)
        {
            for (int i = 0; i < ApplianceList.Length; i++)
            {
                ApplianceList[i].SetActive(i == index);
            }
        }
    }
    public sealed class ButtonListButton : MonoBehaviour
    {
        [SerializeField]
        public int Index;
        [SerializeField]
        ButtonListControl List;
        // This asks the list to hide every button except for this one
        public void HideOthers()
        {
            List.HideAllBut(Index);
        }
    }
