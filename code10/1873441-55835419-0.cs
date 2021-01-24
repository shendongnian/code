    public class Quests : MonoBehaviour
    {
        public Text taskText;
    	public Quest SelectedQuest { get; private set; } 
	
        private void Start()
        {
            SelectedQuest = SelectQuest();
            taskText.text = SelecedQuest?.discription; //doesnt exist
        }
        public void SelectQuest()
        {
		    Quest retVal = null;
            int random = Random.Range(0, 3);
            switch (random)
            {
                case 0:
                    retVal = new Quest("Set new record to reward");
                    break;
                case 1:
                    retVal = new Quest(1000, "Collect 1000 coins to reward");
                    break; //quest cannot be assign because it used on case 0
                case 2:
                    retVal = new Quest(5000, "Get 5000 score to reward");
                    break; //quest cannot be assign because it used on case 0
			    default:
				    break;
            }
		    return retVal;
        }
    }
