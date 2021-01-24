using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
public class TimelineController : MonoBehaviour {
    public List<PlayableDirector> playableDirectors;
    public List<TimelineAsset> timelines;
    public List<GameObject> gameObjects;
    public int index = 0;
    public int currindex = 0;
    private void Awake()
    {
        playableDirectors[index].Play();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            if (currindex == timelines.Count - 1)
            {
                index = timelines.Count - 1;
            }
            else
            {
                index = currindex + 1;
                PlayTimelines();
            }
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            if (currindex == 0)
            {
                index = 0;
            }
            else
            {
                index = currindex - 1;
                PlayTimelines();
            }
        }
    }
    public void PlayTimelines()
    {
        gameObjects[index].SetActive(true);
        playableDirectors[index].Play();
        StopTimeline();
    }
    public void StopTimeline()
    {
        playableDirectors[currindex].time = 0;
        playableDirectors[currindex].Stop();
        playableDirectors[currindex].Evaluate();
        gameObjects[currindex].SetActive(false);
        currindex = index;
    }
}
