    private List<Shooting> shooters;
    void Start() {
        GameObject[] shooterObjects = GameObject.FindGameObjectsWithTag("Shooter");
        shooters = new List<Shooting>(shooterObjects.Length);
        for (int i = 0; i < shooterObjects.Length; i++)
        {
            //Can throw an error if any gameObject with Shooter tag doesnt
            //have a Shooting attached to it.
            shooters[i] = shooterObjects[i].GetComponent<Shooting>();
        }
        ShootingSettings();
    }
