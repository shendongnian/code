    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class bullet : MonoBehaviour{
	public float turnLength = 0.5f; // how long it turns for 0.0+
	public float turnSpeed = 5f; // how fast the projectile turns 0.0+ 
    public float anglePauseTime = 0.2f; // Optional wave form variable. coupled with high turnrate + curve speed = higher frequency sine wave.
    public float shotAngle = -12f; // the angle the shot is taken as an offset (usually nagative value) 0- or turnspeed*2.25 for straight shots
    public float projectileSpeed = 50; // obvious
    public bool opositeAngles = false;
    // Start is called before the first frame update
    void Start(){
        if(opositeAngles){
            transform.Rotate(0, 0, -shotAngle);
        }
        else{
            transform.Rotate(0, 0, shotAngle);
        }
         
		StartCoroutine(WaveForm(turnLength, turnSpeed, anglePauseTime, opositeAngles));
    }
    // Update is called once per frame
    void Update(){
        transform.position += transform.right * Time.deltaTime * projectileSpeed;
    }
    IEnumerator WaveForm(float seconds, float aglSpeed, float pause, bool reverse){
        // multiplier correlates to waitForSeconds(seconds)  
        // faster update time = smoother curves for fast projectiles
        // less cycles = shorter Corutine time. 
        //10, 0.1   100cycles/second (shallow waves, jagged on higher frequency waves, doesnt last long)
        //10, 0.05  200cycles/second (probably best)
        //100, 0.02 500cycles/second (smooth curves all around. requires smaller adjustment numbers)
        // i had to up it for the waveform to last longer. 
        float newSeconds = seconds * 10; 
		for (int i = 0; i < newSeconds; i++) {
			for (int j = 0; j < newSeconds; j++) {
                yield return new WaitForSeconds(0.05f); // controls update time in fractions of a second. 
                if(reverse){
                    transform.Rotate(0, 0, -aglSpeed, Space.Self);
                }
                else {
                    transform.Rotate(0, 0, aglSpeed, Space.Self);
                }
			}
			yield return new WaitForSeconds(pause);
			aglSpeed = -aglSpeed;
		}
	}
    }
