    Included local variable within the LoadMapForRound for the Global Variable to be equal to.
    
        private void LoadMapForRound()
        {
            int mapChosen = Random.Range(2, 4); Solution Line
            LevelLoaded = mapChosen;
            SceneManager.LoadScene(LevelLoaded, LoadSceneMode.Additive);
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
            //Debug.Log("SceneLoaded");
        }
