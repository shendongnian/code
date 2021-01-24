    public class ListContainer
    {
    public List<PlayerHandler> SaveValues;
    public List<PlayerMovement> NoteValues;
    
  
    public ListContainer(List<PlayerHandler> _saveVal, List<PlayerMovement> _noteVal)
    {
        SaveValues = _saveVal;
        NoteValues = _noteVal;
    }
    }
    [System.Serializable]
    public class PlayerHandler 
    {
    public int id; 
    public Vector2 allposition;
    public Quaternion allrotation;
    public Vector2 allscale;
    public Vector3 linepos0;
    public Vector3 linepos1;
    public int movetype;
    public PlayerHandler(int ids,Vector2 allpos,Quaternion allrot,Vector2 allscal,Vector3 Line0,Vector3 Line1,int Moves)
   
    {
        this.id = ids;
        this.allposition = allpos;
        this.allrotation = allrot;
        this.allscale = allscal;
        this.linepos0 = Line0;
        this.linepos1 = Line1;
        this.movetype = Moves;
    }
    
    }
    [System.Serializable]
    public class PlayerMovement
    {
    public int movenumber;
    public string notemsg;
    public PlayerMovement(int Movenum,string Note)
    {
        this.movenumber = Movenum;
        this.notemsg = Note;
    }
    }
    //Added to retrieve data
    [System.Serializable]
    public class RootObject
    {
        public PlayerHandler[] SaveValues;
        public PlayerMovement[] NoteValues;
        
        }
    //Added to retrieve data
    [System.Serializable]
    public class RootObjects
    {
   
     public RootObject[] Roots;
    }
