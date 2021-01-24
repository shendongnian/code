    private void Start()
    {
        Debug.Log("GameHandler.Start");
        car = new Car(); // you must initialize objects before using them!
        //GameObject carHeadGameObject = new GameObject();
        //SpriteRenderer carSpriteRenderer = carHeadGameObject.AddComponent<SpriteRenderer>();
        //carSpriteRenderer.sprite = GameAssets.instance.carHeadSprite;
        levelGrid = new LevelGrid(20,20); //width,height of grid
        car.Setup(levelGrid);
        levelGrid.Setup(car);
    }
