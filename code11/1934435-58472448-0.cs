    for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
    {
        int index = i;
        GameObject go = Instantiate(button, grid);
        Button btn = go.GetComponent<Button>();
        btn.GetComponentInChildren<TextMeshProUGUI>().text = i.ToString();
        btn.onClick.AddListener(() => {
            SceneManager.LoadScene(index);
        });     
    }
