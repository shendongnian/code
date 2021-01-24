    public void showRange(){
    if (gamemanager.Instance.selected) {
        for (int i = 0; i < tileRange.Count; i++) {
            tileRange [i].GetComponent<SpriteRenderer> ().enabled = true;
        } 
    } else {
            for (int i = 0; i < tileRange.Count; i++) {
                tileRange [i].GetComponent<SpriteRenderer> ().enabled = false;
        }
    }
    }
