    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.Tag == "tile"){
            Debug.Log("touching");
        }
    }
