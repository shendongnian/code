    protected CharacterBase characterBase;
    public void Init(CharacterBase _characterBase)
    {
        characterBase = _characterBase;
    }
now Start() looks like this
private void Start()
    {
        GameObject TestPlayer = Instantiate(TestObjectPrefab);
        TestPlayer.name = "p";
        PlayerController pController = TestPlayer.AddComponent<PlayerController>();
        pController.Init(pController.playerBase);
        pController.TakeDamage();  
    }
That does it!! no more duplicate fields! And proper output in Debug.Log - Thanks Guys!
