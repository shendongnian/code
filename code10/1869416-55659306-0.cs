    //Reference parent gameobject
    [SerializeField]
    private GameObject gridContainer;
    //List of all child elements
    private List<Button> gridObjects = new List<Button>();
    private void Start(){
      //Loop through all children
      for(int i = 0; i < gridContainer.transform.childCount; i++){
        //Add button to list
        gridObjects.Add(gridContainer.transform.getChild(i).gameObject.GetComponent<Button>());
      }
      
      //Set listeners for buttons
      
      for(int i = 0; i < gridObjects.Count;i++){
        gridObjects[i].onClick.AddListener(delegate{
          DoSomething();
        });
      }
    }
    private void DoSomething(){
      //Do Something
    }
