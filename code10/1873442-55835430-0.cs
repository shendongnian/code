public class Quests : MonoBehaviour
{
    public Text taskText;
    private void Start()
    {
        var quest = SelectQuest();
        taskText.text = quest.discription; //doesnt exist
    }
    public Quest SelectQuest()
    {
        int random = Random.Range(0, 3);
        switch (random)
        {
            case 0:
                return new Quest("Set new record to reward");
                break;
            case 1:
                return new Quest(1000, "Collect 1000 coins to reward");
                break; //quest cannot be assign because it used on case 0
            case 2:
                return new Quest(5000, "Get 5000 score to reward");
                break; //quest cannot be assign because it used on case 0
        }
    }
}
