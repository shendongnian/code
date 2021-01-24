unity
var ps = gameObject2.GetComponentInChildren<ParticleSystem>();
// Copy the value of the property
var newShape = ps.shape;
// Make modifications
newShape.radius = objectNode2.GameObject.GetComponent<CharacterController>().radius;
// Assign the new value to the property
ps.shape = newShape;
