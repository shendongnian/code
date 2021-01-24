public class LevelData : MonoBehaviour {
    public string LevelName;
    public int HighScoreStarsCollected;
    public int StarsCollected;
    void Awake() {
        HighScoreStarsCollected = PlayerPrefs.GetInt(LevelName + ".starscollected", 0);
    }
    public void SaveData() {
        PlayerPrefs.SetInt(LevelName + ".starscollected", HighScoresCollected);
    }
    public bool UpdateHighScore() {
        if(StarsCollected > HighScoreStarsCollected) {
            HighScoreStarsCollected = StarsCollected;
            SaveData();
            return true;
        }
        return false;
    }
}
Then in your Stars class add a public variable to reference the LevelData..
public class Stars : MonoBehaviour {
    [SerializeField] private Animator animator;
    public GameObject DeathEffect;
    public LevelData Data;
    void didColideWithStar()
    {
        animator.SetBool("boom", true);
        Data.StarsCollected++; // increment the star count
    }
    public void OnTriggerEnter2D()
    {
        didColideWithStar();
        Die();
    }
    public void Die()
    {
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
Now you have a class that holds the total of the stars collected, and you can reference that for your score.
You will most likely want to extend that to have a Reset/Save/Load function(s) to allow replaying, and persiting data between game runs.
