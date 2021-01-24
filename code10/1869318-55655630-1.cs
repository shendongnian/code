    float pointerDownTimer = 0;
    const float requiredHoldTime = 0.5f //has to hold for 0.5 seconds
    void Update(){
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
           pointerDownTimer += Time.deltaTime; 
           if (pointerDownTimer >= requiredHoldTime){
               ...... //whatever happens when you click
           }
        } else{
           pointerDownTimer = 0;
        }
    }
