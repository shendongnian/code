using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveTwoTransforms : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    bool HeadingtowardsB;
    bool HeadingtowardsA;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = pointA.position;
        HeadingtowardsB = true;
        HeadingtowardsA = false;
        StartCoroutine(GlideAround());
    }
    // Update is called once per frame
    void Update()
    {
    }
    public IEnumerator GlideAround()
    {
		float distance = Vector3.Distance(pointA, pointB) * 2;
		float lapTime = distance / speed;
		float startTime = Time.time; 
        while (true)
        {
			yield return new WaitForEndOfFrame();
			float elapsedTime = (Time.time - startTime) % (lapTime / 2);
			float progress = elapsedTime / lapTime;
			if (progress > 1){
				progress = 2 - progress;
			}
			transform.position = Vector2.Lerp(transform.position, pointB.position, progress);
    }
}
As I mentioned in the comments, you Lerp uses a percentage between two points as the return value. You need to give it a percent, not a speed.
Here is an implementation that uses speed, like you wanted, but @derHugo's answer with PingPong is much simpler!
