    public Queue<string> sentences;
    private bool dialogueStarted;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    private void Update()
    {
        if(dialogueStarted && Input.GetKeyDown(GameObject.Find("Player").GetComponent<Controls>().confirm))
        {
            displayNextSentence();
        }
    }
    public void startDialogue(Dialogue dialogue)
    {
        print("start:" + dialogue.name);
        sentences.Clear();
        foreach (string s in dialogue.sentences)
        {
            sentences.Enqueue(s);
        }
        displayNextSentence();
        dialogueStarted = true;
    }
    public void displayNextSentence()
    {
        if (sentences.Count == 0)
        {
            endDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        
        Debug.Log(sentence);
    }
    private void endDialogue()
    {
        Debug.Log("End of dialogue");
        dialogueStarted = false;
    }
