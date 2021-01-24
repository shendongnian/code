    bool isModel1;
    private void ChangeModel()
    {
        isModel1 = !isModel1;
        model.SetActive(!isModel1);
        model1.SetActive(isModel1);
    }
