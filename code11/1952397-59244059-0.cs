    public void AddBtn()
    {
        RemoveButton();
        for (int i = 0; i < items.Count; i++)
        {
            indexer = i;
            ShopItem activeOne = items[indexer];
            go = Instantiate(prefabBtn, parentBtn);
            btn = go.GetComponent<_button>();
            btn.indexer = indexer;
            btn.TheItems.sprite = items[indexer].theitem;
            btn.button.onClick.AddListener(() =>chooseItem(btn));
        }
    }
    
    public void chooseItem(_button_ btn)
    {
    
        Debug.Log(btn.indexer);
    }
