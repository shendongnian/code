// A mask determining what is ground to the character
[SerializeField] private LayerMask m_WhatIsGround;
// A position marking where to check if the player is grounded.
[SerializeField] private Transform m_GroundCheck;
// Radius of the overlap circle to determine if grounded
const float k_GroundedRadius = 0.3f;
private void FixedUpdate() {
	is_on_ground = false;
	// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
	// This can be done using layers instead but Sample Assets will not overwrite your project settings.
	Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
	for (int i = 0; i < colliders.Length; i++) {
		if (colliders[i].gameObject != gameObject) {
			is_on_ground = true;
		}
	}
}
A tutorial on this method can be found in this [Brackey's video][1].
  [1]: https://youtu.be/dwcT-Dch0bA?t=180
