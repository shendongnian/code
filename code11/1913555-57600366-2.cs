    void Update()
    {
        if (Interacting == true)
        {
            Debug.Log("Test1");
            obj.GetComponent<NPCMasterScr> ().DialogueActive = true;
        }
        if (Input.GetKeyDown("escape"))
        {
            Interacting = false;
            obj.GetComponent<NPCMasterScr> ().DialogueActive = false;
        }
    }
