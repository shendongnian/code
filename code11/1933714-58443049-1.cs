private void OnTriggerEnter2D(Collider2D other) {
   if (other.gameObject.tag == "Level_1") {
        player.isInside = true;
   }
}
private void OnTriggerExit2D(Collider2D other) {
   if (other.gameObject.tag == "Level_1") {
        player.isInside = false;
   }
}
And use this to check for the spacebar:
 public void Update() {
      if (Input.GetKeyDown(KeyCode.Space) && player.isInside == true) {
        Debug.Log("Both Conditions Reached");
     }
 }
