    private volatile bool _shouldCommunicate = false;
    void Update ()
    {
      if (_shouldCommunicate) // this is a flag you set in "OnGui"
      {
         try {
           stream.Write(" ");
           Debug.Log(stream.ReadLine());
         } catch (Exception e){
           Debug.Log("Error reading input "+e.ToString());
         }
      }
    }
    void OnGUI() // simple GUI
    {
       if (GUI.Button (new Rect(10,10,100,20), "Send"))
          _shouldCommunicate = true;
    }
