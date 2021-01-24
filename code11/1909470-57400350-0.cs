    public GameObject nextObject;
    public GameObject currentObject;
    public GameObject previousObject;
 
    public GameObject lastPreviousObject;
    public GameObject lastObject;
    private bool saveObjectOnce = false;
    private bool isFading = false;
    private bool fadeOnce = false;
    public void Start()
    {
    }
    public void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(Camera.main.transform.position, forward, Color.red);
        //if player is looking
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag("Puzzle") || selection.CompareTag("Clue") || selection.CompareTag("Selectable"))
            {
                nextObject = selection.gameObject;
                //if previous and current object are same
                if (GameObject.Equals(nextObject, currentObject))
                {
                        isFading = true;
                        ColorFade fadingColor = currentObject.GetComponent<ColorFade>();
                        fadingColor.FadeCheck(isFading);
       
                    if(previousObject != null)
                    {
                        isFading = false;
                        ColorFade fadingcolor1 = previousObject.GetComponent<ColorFade>();
                        fadingcolor1.FadeCheck(isFading);
                    }
                    if(GameObject.Equals(currentObject, lastPreviousObject))
                    {
                        lastPreviousObject = null;
                    }
                    else {
                        if (lastPreviousObject != null)
                        {
                            isFading = false;
                            ColorFade fadingcolor = lastPreviousObject.GetComponent<ColorFade>();
                            fadingcolor.FadeCheck(isFading);
                        }
                    }
                    
                }
                //if previous and current object are different
                else
                {
                    lastPreviousObject = previousObject;
                    previousObject = currentObject;
                    currentObject = nextObject;
                }
            }
            //if detects other objects than the items
            else
            {
                isFading = false;
                lastObject = nextObject;
                if (lastObject != null)
                {
                    ColorFade fadingColor = lastObject.GetComponent<ColorFade>();
                    fadingColor.FadeCheck(isFading);
                }
            }
        }
        //if the player is not looking 
        else
        {
            isFading = false;
            lastObject = nextObject;
            if (lastObject != null)
            {
                ColorFade fadingColor = lastObject.GetComponent<ColorFade>();
                fadingColor.FadeCheck(isFading);
            }
        }
