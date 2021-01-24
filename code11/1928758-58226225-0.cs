[RequireComponent(typeof(DamageScript))]
public class HandSpeedMonitor : Monobehaviour
{
    public float threshold;
    DamageScript damageScript;
    Vector3 lastPos;
    public void Awake()
    {
        damageScript = this.GetComponent<DamageScript>();
    }
    public void Start()
    {
        lastPos = this.transform.position;
    }
    public void Update()
    {
        float velocity = (lastPos - this.transform.position).magnitude / Time.deltaTime;
        if(!damageScript.enabled && velocity > threshold)
            damageScript.enabled = true;
        else if(damageScript.enabled)
            damageScript.enabled = false;
    }
}
However, since .magnitude is an expensive call, you may want to consider storing your "threshold" as a squared speed "sqrThreshold" and use .sqrMagnitude, since it removes the square root component of vector math (saving on processing).
