    public Plane Takeoff(string reg){
      for(int i = 0; i < _planes.Count; i++) {
        if(_planes[i].Registration == reg){
           Plane p = _planes[i];
           _planes.RemoveAt(i);
           return p;
        }
      }
    }
