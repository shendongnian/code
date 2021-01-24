    System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    public class TimerScript : MonoBehaviour
    {
    public Text TimerText;
    float CurrentTime = 0f;
    float StartTime = 10f;
    void Start()
    {
    CurrentTime = StartTime;
    }
    void Update()
    {
    float t = CurrentTime -= 1 * Time.deltaTime;
    //TimerText.text = CurrentTime.ToString("0");
    string mins = ((int) t / 60).ToString();
    string secs = (t % 60).ToString("f1");
    TimerText.text = mins + ":" + secs;
    if (CurrentTime <= 0)
    {
        CurrentTime = 0;
    }
    }
    }
