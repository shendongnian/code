public class ScoreScript : MonoBehaviour {
public static int scoreValue = 0;
Text score;
// Use this for initialization
void Start () {
    score = GetComponent<Text>();
}
// Update is called once per frame
void Update () {
    score.text = "Score: " + scoreValue;
}
void ScoreReset() {
    scoreValue = 0;
    Update(); // This line is unnecessary if something else is calling Update
}
void AddPoints(int points) {
    scoreValue += points;
    Update(); // This line is unnecessary if something else is calling Update
}
}
