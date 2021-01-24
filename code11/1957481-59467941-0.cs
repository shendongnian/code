    //Create a list of Raycast Results
    List<RaycastResult> results = new List<RaycastResult>();
    //Raycast using the Graphics Raycaster and mouse click position
    m_Raycaster.Raycast(m_PointerEventData, results);
     //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
    foreach (RaycastResult result in results)
    {
         Debug.Log("Hit " + result.gameObject.name);
    }
