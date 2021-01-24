    public void DisableAllButtonsExcept(int i) {
        foreach(GameObject buttonGameObject in buttonArray) {
            buttonGameObject.SetActive(false);
        }
        buttonArray[i].SetActive(true);
    }
