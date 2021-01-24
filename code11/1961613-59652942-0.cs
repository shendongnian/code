cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameStatus : MonoBehaviour
{
    public Text PointsCounter;
    public int FightPoints = 0;
    public int FightDamage = 1;
    // Start is called before the first frame update
    void Start()
    {
        PointsCounter = new Text(); // may or may not work; depends on if UnityEngine.UI.Text has an empty constructor; it probably doesn't, see explanation below if not
    }
    // Update is called once per frame
    void Update()
    {
        PointsCounter.text = "Points: " + FightPoints;
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
Though, given that you are using Unity, `PointsCounter` probably needs to be assigned using the editor. Go to your Unity Hierarchy and ensure the `GameObject` with this `GameStatus` behavior has a `PointsCounter` property set in the UI
