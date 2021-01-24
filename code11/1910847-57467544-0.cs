    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("White Ball"))
        {
            StartCoroutine(SlowMoveSpeed());
            this.gameObject.SetActive(false);
        }
    }
    IEnumerator SlowMoveSpeed() {
         InteractControl.moveSpeed = 2f; // set slow speed
         yield return new WaitForSeconds(5); // suspend the process for 5 seconds
         InteractControl.moveSpeed = 10f; // 5 seconds later, set speed back
    }
