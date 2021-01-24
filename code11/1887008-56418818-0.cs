    [SerializeField]
    private GameObject itemTemplatePrefab, inventoryTabWeapons;
    public void GenerateItem(string name)
    {
        var item = Instantiate(itemTemplatePrefab);
        item.SetActive(true);
        item.transform.SetParent(inventoryTabWeapons.transform, false);
    }
