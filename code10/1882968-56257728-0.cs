    void Update()
     {
         allInRightPosition = true ;
         foreach (Transform child in transform)
         {
             PanelMove panelMove = child.GetComponent<PanelMove>()
             if( panelMove != null && !panelMove.InRightPosition )
             {
                 allInRightPosition = false;
                 break;
             }
         }
         if( allInRightPosition )
             Destroy( gameObject ) ;
     }
