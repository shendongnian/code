    void SetActiveBodyPart(List<Transform> whichBodyParts, GameObject whichBodyPart)
    {
        if (whichBodyParts == null)
        {
            Debug.Log("whichBodyParts is null");
        }
        else if (!whichBodyParts.Any())
        {
            Debug.Log("whichBodyParts does not contain any items");
        }
        else
        {
            whichBodyPart = whichBodyParts[Random.Range(0, whichBodyParts.Count)].gameObject;
            if (!whichBodyPart.activeSelf)
            {
                whichBodyPart.SetActive(true);
            }
        }
    }
