    GameObject[] objectsWithReplacedColors;
    Color[] originalColors;
    public void OnPointerEnter(PointerEventData eventData)
    {
        ReplaceColors(GameObject.FindGameObjectsWithTag(myMenu.selected.title), Color.red);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        RestoreColors();
    }
    private void ReplaceColors(GameObject[] forObjects, Color withColor)
    {
        if (objectsWithReplacedColors != null)    // if there are already objects with replaced colors, we have to restore those first, or their original color would be lost
            RestoreColors();
        objectsWithReplacedColors = forObjects;
        originalColors = new Color[objectsWithReplacedColors.Length];
        for (int i = 0; i < objectsWithReplacedColors.Length; i++)
        {
            originalColors[i] = objects[i].GetComponent<MeshRenderer>().material.color;
            objectsWithReplacedColors[i].GetComponent<MeshRenderer>().material.color = withColor;
        }
    }
    private void RestoreColors()
    {
        if (objectsWithReplacedColors == null)
            return;
        for (int i = 0; i < objectsWithReplacedColors.Length; i++)
        {
            if (objectsWithReplacedColors[i])    // check if the objects still exists (it may have been deleted since its color was replaced)
                objectsWithReplacedColors[i].GetComponent<MeshRenderer>().material.color = originalColors[i];
        }
        objectsWithReplacedColors = null;
        originalColors = null;
    }
