    private bool touchedGround = false;
    private bool touchedEnemy = false;
    private void LateUpdate() {
       touchedGround = false;
       touchedEnemy = false;
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("ground")) {
            touchedGround = true;
        }
        if (collision.gameObject.CompareTag("enemy")) {
            touchedEnemy = true;
        }
        if (touchedGround && touchedEnemy) {
           isDead = true;
           rb2d.velocity = Vector2.zero;
           GameController.Instance.Die();
        }
    } 
