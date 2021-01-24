    public void FreezeLevelBlockEnemies(int index)
    {
        if (currentBlocks.Count == 3 && freezeEnemiesOutOfCurrentBlock)
        {
            foreach (MouseMovement enemy in currentBlocks[index].GetComponentsInChildren<MouseMovement>())
            {
                enemy.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                Debug.Log("I'm in " + index + " index levelblock freezing");
            }
            foreach (BirdMovement enemy in currentBlocks[index].GetComponentsInChildren<BirdMovement>())
            {
                enemy.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                Debug.Log("I'm in " + index + " index levelblock freezing");
            }
        } else
        {
            Debug.LogWarning("Freeze is disabled");
        }
    }
