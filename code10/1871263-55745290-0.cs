    public class SnapModelToPosition : MonoBehaviour {
	public Rigidbody rb;
	
	Vector3 newPos =  new Vector3(0.1192573f, -0.630803f, 0.02599394f);
	// Use this for initialization
	void Start () {
		rb.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "SnapToPosition")
		{
		
			Destroy(rb);
			this.transform.localPosition = newPos;
			this.transform.localEulerAngles = new Vector3(0, -90.00001f, 0);  
		}
	}
}
