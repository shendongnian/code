float limit = 10f;
Rigidbody2D rig;
void Start(){
  rig = gameObject.transform.GetComponent<Rigidbody2D>();
}
void Update(){
if(Input.GetKeyDown(KeyCode.A && rig.velocity.magnitude < limit){
  rig.AddForce(accelerationVariable);
 }
}
I would use Rigidbody.velocity.magnitude because it gives you the length of the vector.
If you just want to check the x-Force use Rigidbody.velocity.x
Hope that helps
