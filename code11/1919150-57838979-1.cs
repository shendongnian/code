    // Update is called once per frame
    void Update()
    {
        // Using GetKeyDown so it runs only once, GetKey runs for every frame the key is held
        if (Input.GetKeyDown("k"))
        {
            Debug.Log("K");
            diaSysObject = GameObject.Find("DialogueSystem");
            diaSysScript = diaSysObject.GetComponent<DialogueSystem>();
            testLine = diaSysScript.justSaid;
            testName = diaSysScript.justSpoke;
            Debug.Log("testLine post copy: " + testLine);
            diaJournal.Add(new DiaEntryClass(string.Copy(testLine), "Bernard's Apartment + copy Method", string.Copy(testName)));
            diaJournal.Add(new DiaEntryClass(testLine, "Bernard's Apartment + non-copy method", testName));
            int index = 0;
            // Foreach to just loop through every entry
            foreach (DiaEntryClass dec in diaJournal)
            {
                Debug.Log("Dialogue Journal, Entry " + index + ", Line: " + dec.line);
                Debug.Log("Dialogue Journal, Entry " + index + ", Character: " + dec.character);
                Debug.Log("Dialogue Journal, Entry " + index + ", Location: " + dec.location);
                index++;
            }
        }
    }
