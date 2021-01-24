    public Sprite MondayRW;
    public Sprite MondayRG;
    public Sprite TuesRW;
    public Sprite TuesRG;
    public Sprite WendRW;
    public Sprite WendRG;
    public Sprite ThurRW;
     
    //If Phone language is Russian, Set Russian value images to tonggles.
            if(Application.systemLanguage == SystemLanguage.Russian)
            { 
                GameObject.Find("BackgroundMon").GetComponent<Image>().sprite = MondayRW;
                GameObject.Find("CheckmarkMon").GetComponent<Image>().sprite = MondayRG;
                GameObject.Find("BackgroundTue").GetComponent<Image>().sprite = TuesRW;
                GameObject.Find("CheckmarkTue").GetComponent<Image>().sprite = TuesRG;
                GameObject.Find("BackgroundWed").GetComponent<Image>().sprite = WendRW;
                GameObject.Find("CheckmarkWed").GetComponent<Image>().sprite = WendRG;
                GameObject.Find("BackgroundThu").GetComponent<Image>().sprite = ThurRW;
             
            }
