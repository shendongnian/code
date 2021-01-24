public class Storyteller : MonoBehaviour
{
    [SerializeField] RPGTalk rpgTalk;
    [SerializeField] UIManager uiMgr;
    [Header("NPCs with changing dialogues")]
    [SerializeField] GameObject flowerLady;
    [SerializeField] GameObject hippie;
    [SerializeField] GameObject trashcan;
    [SerializeField] List<string> tempNPCSpoken;
    [Header("Saved stats access")]
    SaveManager saveManager;
    [Header("Music")] 
    [SerializeField] AudioClip successSFX;
    public delegate void StorytellerDelegate(float statChange);  
    public static event StorytellerDelegate ReceiveMedicinalHerbsEvent;
    // ADDED THIS IN FROM DIALOGUE PROGRESS SCRIPT
    private void Awake()
    {
        saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager>();
        if (saveManager.myStats.NPCSpoken.Count == 0)
        {
            // There are no NPCs saved in the list.
            Debug.Log("AWAKE in DialogueProgress: NPCSpoken was empty. Making a new tempList.");
            tempNPCSpoken = new List<string>(); // Create a new list object that is empty.
        }
        else
        {   // There are NPCs that are in the saved list.
            Debug.Log("AWAKE in DialogueProgress: There are NPCs saved. NPCSpoken count is " + saveManager.myStats.NPCSpoken.Count);
            tempNPCSpoken = saveManager.myStats.NPCSpoken; // Save a local list equal to save one.
        }
    }
    // NPC ADDER
    public void NPCSpokenAdder(string npcname)
    {
        // Called from Question and ChoiceID script
        tempNPCSpoken.Add(npcname); // Add the NPC to local list.
        saveManager.myStats.NPCSpoken = tempNPCSpoken; // Set the save list equal to this list.
        saveManager.Save(); // Save the game.
        Debug.Log("NPCSpokenAdder ran: " + npcname + " was added to Saved List");
        Debug.Log("Current saved list: It contains this.gameObject now: " + saveManager.myStats.NPCSpoken.Contains(npcname));
    }
    //NPC Callbacks
    public void RewardFromFlowerLady()
    {
        saveManager.myStats.coins += 700;
        saveManager.Save();
    }
    public void RewardFromHippie()
    {
        ReceiveMedicinalHerbsEvent(1.1f);
        saveManager.Save();
    }
    public void PetFromTrashCan()
    {
        saveManager.myStats.trashcat = 1;
        saveManager.Save();
    }
  }
QuestionAndChoiceID.cs
public class QuestionAndChoiceID : MonoBehaviour
{
    public string questionID;
    public int correctchoiceID;
    RPGTalk rpgTalk;
    RPGTalkArea talkArea;
    SaveManager saveManager;
   // DialogueProgress dialogueProgress;
    Storyteller storyTeller;
    void Start()
    {
        saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager>();
        rpgTalk = GameObject.FindGameObjectWithTag("RPGTalk").GetComponent<RPGTalk>();
        talkArea = GetComponent<RPGTalkArea>();
        rpgTalk.OnMadeChoice += OnMadeChoice;
        //dialogueProgress = FindObjectOfType<DialogueProgress>();
        storyTeller = FindObjectOfType<Storyteller>();
        LoadCorrectResponses();
    }
    private void OnMadeChoice(string question, int choice)
    {
       // Debug.Log("OnMadeChoice: Player just made an RPGTalk choice.");
        if (question == questionID && choice == correctchoiceID) // If they answer NPC correctly
        {
            Debug.Log("OnMadeChoice: Player just made an RPGTalk choice that has actions attached.");
            switch (this.gameObject.name) // check which NPC it is by name
            {
                case "FlowerLady":
                    storyTeller.NPCSpokenAdder(this.gameObject.name); // NAME ADDED TO LIST, SAVED
                    IncrementDialogue(); // TALK LINES UPDATED
                    storyTeller.RewardFromFlowerLady(); // REWARD
                    break;
                case "Hippie":
                    storyTeller.NPCSpokenAdder(this.gameObject.name);
                    IncrementDialogue();
                    storyTeller.RewardFromHippie();
                    break;
                case "TrashCan":
                    storyTeller.NPCSpokenAdder(this.gameObject.name);
                    IncrementDialogue();
                    storyTeller.PetFromTrashCan();
                    break;
            }
        }
    }
    private void IncrementDialogue()
    {
        //if (saveManager.myStats.NPCSpoken.Contains(this.gameObject.name))
        //    {
                talkArea.lineToStart = this.gameObject.name + 1;
                talkArea.lineToBreak = this.gameObject.name + 1 + "_end";
            //}
    }
    private void LoadCorrectResponses()
    {
        if (SaveManager.saveExists) 
        {
            if (saveManager.myStats.NPCSpoken != null) // If NPC list is not null
            { 
                // If the NPC is the array when this is called, the dialogue on that NPC is incremented.
                if (saveManager.myStats.NPCSpoken.Contains(this.gameObject.name)) 
                {
                    talkArea.lineToStart = this.gameObject.name + 1; 
                    talkArea.lineToBreak = this.gameObject.name + 1 + "_end";
                }
                else
                {
                    Debug.Log("LoadCorrectResponses(): List does not contain NPC " + this.gameObject.name);
                }
            }
        }
    }
}
My current Stats.cs 
public class Stats
{
    [Header("NPC Talk Saves")]
    public List<string> NPCSpoken = new List<string>();
}
I will close this issue off as it's resolved.
