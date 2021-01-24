    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            UnlockSlot++;
            // for reading in this case it doesn't matter
            // but for being consequent I would also use the property here
            Debug.Log(UnlockSlot);
        }
    }
