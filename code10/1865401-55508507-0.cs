    void OnTriggerEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("gem")){
              GemScript gemScript = other.gameObject.GetComponent<GemScript>();
              if(!gemScript.isUsed){
               DO YOU STUFF HERE
               gemScript.isUsed = true;
              }
        }
    }
`
