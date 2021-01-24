    if (whichBodyParts != null && whichBodyParts.Count > 0)
    {
        whichBodyPart = whichBodyParts[Random.Range(0, whichBodyParts.Count)].gameObject;
        if (!whichBodyPart.activeSelf)
        {
            whichBodyPart.SetActive(true);
        }
    }
    else Debug.Log("Nothing here...");
